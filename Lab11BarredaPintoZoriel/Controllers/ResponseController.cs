using Lab10BarredaPintoZoriel.Application.Commands.CreateResponse;
using Lab10BarredaPintoZoriel.Application.Queries.GetAllResponse;
using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab10BarredaPintoZoriel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponseController(IMediator mediator)
    {
        _mediator = mediator;
    }
        

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ResponseCreateDTo dto)
    {
        await _mediator.Send(new CreateResponseCommand(dto));
        return Ok(new { message = "Respuesta registrada correctamente" });
    }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responses = await _mediator.Send(new GetAllResponsesQuery());
            return Ok(responses);
        }
    }