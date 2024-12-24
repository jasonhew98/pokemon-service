using Api.Models.Pokemon;
using Api.Seedwork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.JapanesePokemons;

[Route("api/pokemons/jp")]
[ApiController]
public class JapanesePokemonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JapanesePokemonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("sets")]
    [ProducesResponseType(typeof(List<PokemonSetDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetJapanesePokemonSetsAsync([FromQuery] GetJapanesePokemonSetsQuery query)
    {
        return this.OkOrError(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("sets/{id}")]
    [ProducesResponseType(typeof(PokemonSetDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetJapanesePokemonSetAsync(string id)
    {
        return this.OkOrError(await _mediator.Send(new GetJapanesePokemonSetQuery { Id = id }));
    }

    [HttpGet]
    [Route("cards/{id}")]
    [ProducesResponseType(typeof(PokemonDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetJapanesePokemonByIdAsync(string id)
    {
        return this.OkOrError(await _mediator.Send(new GetJapanesePokemonQuery { Id = id }));
    }

    [HttpGet]
    [Route("cards")]
    [ProducesResponseType(typeof(PokemonDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetJapanesePokemonBySetAsync([FromQuery] GetJapanesePokemonsQuery query)
    {
        return this.OkOrError(await _mediator.Send(query));
    }
}
