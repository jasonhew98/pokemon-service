﻿using Api.Infrastructure.Services;
using Api.Models.Pokemon;
using Api.Seedwork.ApiResponse;
using CSharpFunctionalExtensions;
using MediatR;

namespace Api.Controllers.JapanesePokemons;

public class GetJapanesePokemonSetQuery : IRequest<Result<PokemonSetDto, ErrorResponse>>
{
    public required string Id { get; set; }
}

public class GetPokemonSetQueryHandler : IRequestHandler<GetJapanesePokemonSetQuery, Result<PokemonSetDto, ErrorResponse>>
{
    private readonly IPokemonJapaneseService _pokemonService;

    public GetPokemonSetQueryHandler(IPokemonJapaneseService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    public async Task<Result<PokemonSetDto, ErrorResponse>> Handle(GetJapanesePokemonSetQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _pokemonService.GetPokemonSetAsync(request.Id);
            if (result.IsFailure)
                return ApiResponse.Error<PokemonSetDto>(result.Error);
            if (result.Value == null)
                return ApiResponse.NotFound<PokemonSetDto>($"Unable to find pokemon set. Id: {request.Id}");

            return ApiResponse.Success(result.Value);
        }
        catch (Exception ex)
        {
            return ApiResponse.Error<PokemonSetDto>(ex);
        }
    }
}