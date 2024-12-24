namespace Api.Models.Pokemon;

public class PokemonSetDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public int CardCount { get; set; }
    public int PrintedCount { get; set; }
}
