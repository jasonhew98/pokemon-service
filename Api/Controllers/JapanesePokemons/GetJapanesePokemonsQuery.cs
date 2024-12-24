using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.JapanesePokemons;

public class GetJapanesePokemonsQuery : IRequest<Result<List<PokemonDto>, ErrorResponse>>
{
    public required string SetId { get; set; }
}

public class GetPokemonsQueryHandler : IRequestHandler<GetJapanesePokemonsQuery, Result<List<PokemonDto>, ErrorResponse>>
{
    private readonly IPokemonJapaneseService _pokemonService;

    public GetPokemonsQueryHandler(IPokemonJapaneseService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<List<PokemonDto>, ErrorResponse>> Handle(GetJapanesePokemonsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _pokemonService.GetPokemonsAsync(setId: request.SetId);
            if (result.IsFailure)
                return ApiResponse.Error<List<PokemonDto>>(result.Error);

            return ApiResponse.Success(result.Value);
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<List<PokemonDto>>(ex);
        }
    }
}
