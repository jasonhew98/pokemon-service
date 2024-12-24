using Api.Models;

namespace Api.Infrastructure.Services.ServiceModels.Pokemon.English;

/// <summary>
/// A class that represents the raw JSON response from Pokemon English API
/// for an array of sets.
/// </summary>
public class PokemonSetListRawResponse : Paginate
{
    public IEnumerable<PokemonSetRawDto> Data { get; set; } = [];
}

/// <summary>
/// A class that represents the raw JSON response from Pokemon English API
/// for a single set.
/// </summary>
public class PokemonSetRawResponse
{
    public required PokemonSetRawDto Data { get; set; }
}

/// <summary>
/// A class that represents the set object from raw JSON response.
/// </summary>
public class PokemonSetRawDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Series { get; set; }
    public required int PrintedTotal { get; set; }
    public required int Total { get; set; }
    public required PokemonSetImageRawDto Images { get; set; }
    public DateTime ReleaseDate { get; set; }
}

/// <summary>
/// A class that represents the image object from raw JSON response.
/// </summary>
public class PokemonSetImageRawDto
{
    public string? Symbol { get; set; }
    public string? Logo { get; set; }
}
