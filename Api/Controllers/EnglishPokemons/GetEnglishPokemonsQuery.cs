using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.EnglishPokemons;

public class GetEnglishPokemonsQuery : IRequest<Result<List<PokemonDto>, ErrorResponse>>
{
    public required string SetId { get; set; }
    public int PageSize { get; set; } = 250;
    public int CurrentPage { get; set; } = 1;
}

public class GetPokemonsQueryHandler : IRequestHandler<GetEnglishPokemonsQuery, Result<List<PokemonDto>, ErrorResponse>>
{
    private readonly IPokemonEnglishService _pokemonService;

    public GetPokemonsQueryHandler(IPokemonEnglishService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<List<PokemonDto>, ErrorResponse>> Handle(GetEnglishPokemonsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _pokemonService.GetPokemonsAsync(
                setId: request.SetId,
                pageSize: request.PageSize,
                currentPage: request.CurrentPage);
            if (result.IsFailure)
                return ApiResponse.Error<List<PokemonDto>>(result.Error);
            if (result.Value == null)
                return ApiResponse.Success(new List<PokemonDto>());

            return ApiResponse.Success(result.Value);
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<List<PokemonDto>>(ex);
        }
    }
}
