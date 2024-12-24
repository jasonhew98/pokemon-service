using Newtonsoft.Json;

namespace Api.Infrastructure.Services.ServiceModels.Pokemon.Japanese;

public class PokemonSetRawDto
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("image_url")]
    public required string ImageUrl { get; set; }

    [JsonProperty("card_count")]
    public int CardCount { get; set; }

    [JsonProperty("printed_count")]
    public int PrintedCount { get; set; }
}
