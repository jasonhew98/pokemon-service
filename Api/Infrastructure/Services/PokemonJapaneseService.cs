using Api.Extensions;
using Api.Infrastructure.Services.ServiceModels.Pokemon.Japanese;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using System.Net;

namespace Api.Infrastructure.Services;

public class PokemonJapaneseService : IPokemonJapaneseService
{
    private readonly HttpClient _httpClient;

    public PokemonJapaneseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

#pragma warning disable CS8604 // Possible null reference argument.

    public async Task<Result<List<PokemonSetDto>, ErrorResponse>> GetPokemonSetsAsync()
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync("set");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<List<PokemonSetDto>> (new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<List<PokemonSetRawDto>>(responseContent);

            return result.ToDtos();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<List<PokemonSetDto>>(ex);
        }
    }

    public async Task<Result<PokemonSetDto, ErrorResponse>> GetPokemonSetAsync(string id)
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync($"set/{id}");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<PokemonSetDto>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonSetRawDto>(responseContent);

            return result.ToDto();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonSetDto>(ex);
        }
    }

    public async Task<Result<List<PokemonDto>, ErrorResponse>> GetPokemonsAsync(string setId)
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync($"card/set_id={setId}");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<List<PokemonDto>>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonListRawResponse>(responseContent);

            return result?.Data.ToDtos();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<List<PokemonDto>>(ex);
        }
    }

    public async Task<Result<PokemonDto, ErrorResponse>> GetPokemonAsync(string id)
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync($"card/id={id}");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<PokemonDto>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonListRawResponse>(responseContent);

            return result?.Data.First().ToDto();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonDto>(ex);
        }
    }

#pragma warning restore CS8604 // Possible null reference argument.
}
