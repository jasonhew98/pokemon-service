using Api.Models.Pokemon;
using Api.Seedwork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.EnglishPokemons;

[Route("api/pokemons/en")]
[ApiController]
public class EnglishPokemonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnglishPokemonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("sets")]
    [ProducesResponseType(typeof(List<PokemonSetDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetEnglishPokemonSetsAsync([FromQuery] GetEnglishPokemonSetsQuery query)
    {
        return this.OkOrError(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("sets/{id}")]
    [ProducesResponseType(typeof(PokemonSetDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetEnglishPokemonSetAsync(string id)
    {
        return this.OkOrError(await _mediator.Send(new GetEnglishPokemonSetQuery { Id = id }));
    }

    [HttpGet]
    [Route("cards")]
    [ProducesResponseType(typeof(List<PokemonDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetEnglishPokemonsAsync([FromQuery] GetEnglishPokemonsQuery query)
    {
        return this.OkOrError(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("cards/{id}")]
    [ProducesResponseType(typeof(PokemonDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetEnglishPokemonAsync(string id)
    {
        return this.OkOrError(await _mediator.Send(new GetEnglishPokemonQuery { Id = id }));
    }
}
