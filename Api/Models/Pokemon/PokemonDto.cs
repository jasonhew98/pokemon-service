namespace Api.Models.Pokemon;

public class PokemonDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public required int PrintedNumber { get; set; }
}
