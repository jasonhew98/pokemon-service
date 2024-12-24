using Api.Models;
namespace Api.Infrastructure.Services.ServiceModels.Pokemon.Japanese;

public class PokemonListRawResponse : Paginate
{
    public IEnumerable<PokemonRawDto> Data { get; set; } = [];
}

public class PokemonRawDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public required int SequenceNumber { get; set; }
    public required int PrintedNumber { get; set; }
}
