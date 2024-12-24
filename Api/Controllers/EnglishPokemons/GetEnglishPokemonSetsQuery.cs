using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.EnglishPokemons;

public class GetEnglishPokemonSetsQuery : IRequest<Result<List<PokemonSetDto>, ErrorResponse>>
{
}

public class GetPokemonSetsQueryHandler : IRequestHandler<GetEnglishPokemonSetsQuery, Result<List<PokemonSetDto>, ErrorResponse>>
{
    private readonly IPokemonEnglishService _pokemonService;

    public GetPokemonSetsQueryHandler(IPokemonEnglishService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<List<PokemonSetDto>, ErrorResponse>> Handle(GetEnglishPokemonSetsQuery request, CancellationToken cancellationToken)
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
