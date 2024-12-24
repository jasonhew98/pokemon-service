using Api.Models;

namespace Api.Infrastructure.Services.ServiceModels.Pokemon.English;

public class PokemonListRawResponse : Paginate
{
    public IEnumerable<PokemonRawDto> Data { get; set; } = [];
}

public class PokemonRawResponse
{
    public required PokemonRawDto Data { get; set; }
}

public class PokemonRawDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required int Number { get; set; }
    public required PokemonImageRawDto Images { get; set; }
}

public class PokemonImageRawDto
{
    public required string Small { get; set; }
    public required string Large { get; set; }
}
