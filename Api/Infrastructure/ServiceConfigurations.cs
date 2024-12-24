namespace Api.Infrastructure;

public class PokemonRepositoryOptions
{
    public required string MongoDbUrl { get; set; }
    public required string Database { get; set; }
}

public class PokemonEnglishServiceConfigurationOptions
{
    public required string ApiKey { get; set; }
    public required string ServiceUrl { get; set; }
}

public class PokemonJapaneseServiceConfigurationOptions
{
    public required string ServiceUrl { get; set; }
}