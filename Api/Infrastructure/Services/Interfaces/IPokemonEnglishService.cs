using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;

namespace Api.Infrastructure.Services;

public interface IPokemonEnglishService
{
    /// <summary>
    /// Get a list of pokemon sets.
    /// </summary>
    /// <returns></returns>
    Task<Result<List<PokemonSetDto>, ErrorResponse>> GetPokemonSetsAsync();

    /// <summary>
    /// Get a pokemon set object by id.
    /// </summary>
    /// <returns></returns>
    Task<Result<PokemonSetDto, ErrorResponse>> GetPokemonSetAsync(string id);

    /// <summary>
    /// Get a list of pokemon tcg cards.
    /// </summary>
    /// <returns></returns>
    Task<Result<List<PokemonDto>, ErrorResponse>> GetPokemonsAsync(string setId, int pageSize, int currentPage);

    /// <summary>
    /// Get a pokemon tcg card object by id.
    /// </summary>
    /// <returns></returns>
    Task<Result<PokemonDto, ErrorResponse>> GetPokemonAsync(string id);
}
