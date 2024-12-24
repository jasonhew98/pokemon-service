using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.EnglishPokemons;

public class GetEnglishPokemonQuery : IRequest<Result<PokemonDto, ErrorResponse>>
{
    public required string Id { get; set; }
}

public class GetPokemonQueryHandler : IRequestHandler<GetEnglishPokemonQuery, Result<PokemonDto, ErrorResponse>>
{
    private readonly IPokemonEnglishService _pokemonService;

    public GetPokemonQueryHandler(IPokemonEnglishService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<PokemonDto, ErrorResponse>> Handle(GetEnglishPokemonQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _pokemonService.GetPokemonAsync(id: request.Id);
            if (result.IsFailure)
                return ApiResponse.Error<PokemonDto>(result.Error);
            if (result.Value == null)
                return ApiResponse.NotFound<PokemonDto>($"Unable to find pokemon tcg card. Id: {request.Id}");

            return ApiResponse.Success(result.Value);
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonDto>(ex);
        }
    }
}
