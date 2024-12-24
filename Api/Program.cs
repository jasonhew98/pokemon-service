using Api.Infrastructure;
using Api.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services.Configure<PokemonEnglishServiceConfigurationOptions>(
    builder.Configuration.GetSection("PokemonEnglishServiceConfigurations"));
builder.Services.Configure<PokemonJapaneseServiceConfigurationOptions>(
    builder.Configuration.GetSection("PokemonJapaneseServiceConfigurations"));

builder.Services.AddHttpClient<IPokemonEnglishService, PokemonEnglishService>((serviceProvider, client) =>
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    var configs = serviceProvider.GetService<IOptions<PokemonEnglishServiceConfigurationOptions>>().Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    client.BaseAddress = new Uri(configs.ServiceUrl);
    client.DefaultRequestHeaders.Add("X-Api-Key", configs.ApiKey);
});

builder.Services.AddHttpClient<IPokemonJapaneseService, PokemonJapaneseService>((serviceProvider, client) =>
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    var configs = serviceProvider.GetService<IOptions<PokemonJapaneseServiceConfigurationOptions>>().Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    client.BaseAddress = new Uri(configs.ServiceUrl);
});

var assemblies = Assembly.Load("Api");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assemblies));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
