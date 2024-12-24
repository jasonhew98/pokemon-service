using Api.Models.Pokemon;
using EnglishSet = Api.Infrastructure.Services.ServiceModels.Pokemon.English.PokemonSetRawDto;
using EnglishPokemon = Api.Infrastructure.Services.ServiceModels.Pokemon.English.PokemonRawDto;
using JapaneseSet = Api.Infrastructure.Services.ServiceModels.Pokemon.Japanese.PokemonSetRawDto;
using JapanesePokemon = Api.Infrastructure.Services.ServiceModels.Pokemon.Japanese.PokemonRawDto;

namespace Api.Extensions;

public static class PokemonExtensions
{
    #region English

    public static List<PokemonSetDto> ToDtos(this IEnumerable<EnglishSet> source)
    {
        return source.Select(x => new PokemonSetDto
        {
            Id = x.Id,
            Name = x.Name,
            ImageUrl = x.Images?.Logo,
            CardCount = x.Total,
            PrintedCount = x.PrintedTotal
        }).ToList();
    }

    public static PokemonSetDto ToDto(this EnglishSet source)
    {
        return new PokemonSetDto
        {
            Id = source.Id,
            Name = source.Name,
            ImageUrl = source.Images?.Logo,
            CardCount = source.Total,
            PrintedCount = source.PrintedTotal
        };
    }

    public static List<PokemonDto> ToDtos(this IEnumerable<EnglishPokemon> source)
    {
        return source.Select(x => new PokemonDto
        {
            Id = x.Id,
            Name = x.Name,
            ImageUrl = x.Images.Small,
            PrintedNumber = x.Number
        }).ToList();
    }

    public static PokemonDto ToDto(this EnglishPokemon source)
    {
        return new PokemonDto
        {
            Id = source.Id,
            Name = source.Name,
            ImageUrl = source.Images.Small,
            PrintedNumber = source.Number
        };
    }

    #endregion

    #region Japanese

    public static List<PokemonSetDto> ToDtos(this List<JapaneseSet> source)
    {
        return source.Select(x => new PokemonSetDto
        {
            Id = x.Id,
            Name = x.Name,
            ImageUrl = x.ImageUrl,
            CardCount = x.CardCount,
            PrintedCount = x.PrintedCount
        }).ToList();
    }

    public static PokemonSetDto ToDto(this JapaneseSet source)
    {
        return new PokemonSetDto
        {
            Id = source.Id,
            Name = source.Name,
            ImageUrl = source.ImageUrl,
            CardCount = source.CardCount,
            PrintedCount = source.PrintedCount
        };
    }

    public static List<PokemonDto> ToDtos(this IEnumerable<JapanesePokemon> source)
    {
        return source.Select(x => new PokemonDto
        {
            Id = x.Id,
            Name = x.Name,
            ImageUrl = x.ImageUrl,
            PrintedNumber = x.PrintedNumber
        }).ToList();
    }

    public static PokemonDto ToDto(this JapanesePokemon source)
    {
        return new PokemonDto
        {
            Id = source.Id,
            Name = source.Name,
            ImageUrl = source.ImageUrl,
            PrintedNumber = source.PrintedNumber
        };
    }

    #endregion
}
