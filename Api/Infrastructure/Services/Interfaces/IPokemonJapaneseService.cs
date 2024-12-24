using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;

namespace Api.Infrastructure.Services;

public interface IPokemonJapaneseService
{

    /// <summary>
    /// Get a list of pokemon sets.
    /// </summary>
    /// <returns></returns>
    Task<Result<List<PokemonSetDto>, ErrorResponse>> GetPokemonSetsAsync();

    /// <summary>
    /// Get a pokemon set by Id.
    /// </summary>
    /// <returns></returns>
    Task<Result<PokemonSetDto, ErrorResponse>> GetPokemonSetAsync(string id);

    /// <summary>
    /// Get a list of pokemons by SetId.
    /// </summary>
    /// <returns></returns>
    Task<Result<List<PokemonDto>, ErrorResponse>> GetPokemonsAsync(string setId);

    /// <summary>
    /// Get a pokemon by Id.
    /// </summary>
    /// <returns></returns>
    Task<Result<PokemonDto, ErrorResponse>> GetPokemonAsync(string id);
}
