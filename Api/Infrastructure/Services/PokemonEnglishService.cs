using Api.Extensions;
using Api.Infrastructure.Services.ServiceModels.Pokemon.English;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Api.Infrastructure.Services;

public class PokemonEnglishService : IPokemonEnglishService
{
    private readonly HttpClient _httpClient;

    public PokemonEnglishService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

#pragma warning disable CS8604 // Possible null reference argument.

    public async Task<Result<List<PokemonSetDto>, ErrorResponse>> GetPokemonSetsAsync()
    {
        try
        {
            var responseMessage = await _httpClient.GetAsync("sets");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<List<PokemonSetDto>>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonSetListRawResponse>(responseContent);

            return result?.Data.ToDtos();
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
            var responseMessage = await _httpClient.GetAsync($"sets/{id}");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<PokemonSetDto>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonSetRawResponse>(responseContent);

            return result?.Data.ToDto();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonSetDto>(ex);
        }
    }

    public async Task<Result<List<PokemonDto>, ErrorResponse>> GetPokemonsAsync(
        string setId,
        int pageSize,
        int currentPage)
    {
        try
        {
            var parameters = new Dictionary<string, string?>
            {
                { "orderBy", "number" },
                { "q", $"set.id:{setId}" },
                { "pageSize", $"{pageSize}" },
                { "page", $"{currentPage}" }
            };
            var url = QueryHelpers.AddQueryString("cards", parameters);
            var responseMessage = await _httpClient.GetAsync(url);
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
            var responseMessage = await _httpClient.GetAsync($"cards/{id}");
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode != HttpStatusCode.OK)
                return ApiResponse.Error<PokemonDto>(new Exception($"{responseMessage.ReasonPhrase} {responseContent}"));

            var result = JsonConvert.DeserializeObject<PokemonRawResponse>(responseContent);

            return result?.Data.ToDto();
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonDto>(ex);
        }
    }

#pragma warning restore CS8604 // Possible null reference argument.
}
