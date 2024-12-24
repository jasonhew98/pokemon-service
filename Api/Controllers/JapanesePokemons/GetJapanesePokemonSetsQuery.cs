using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.JapanesePokemons;

public class GetJapanesePokemonSetsQuery : IRequest<Result<List<PokemonSetDto>, ErrorResponse>>
{
}

public class GetPokemonSetsQueryHandler : IRequestHandler<GetJapanesePokemonSetsQuery, Result<List<PokemonSetDto>, ErrorResponse>>
{
    private readonly IPokemonJapaneseService _pokemonService;

    public GetPokemonSetsQueryHandler(IPokemonJapaneseService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<List<PokemonSetDto>, ErrorResponse>> Handle(GetJapanesePokemonSetsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _pokemonService.GetPokemonSetsAsync();
            if (result.IsFailure)
                return ApiResponse.Error<List<PokemonSetDto>>(result.Error);
            if (result.Value == null)
                return ApiResponse.Success(new List<PokemonSetDto>());

            return ApiResponse.Success(result.Value);
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<List<PokemonSetDto>>(ex);
        }
    }
}
