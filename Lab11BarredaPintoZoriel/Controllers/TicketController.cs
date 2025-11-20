using Lab10BarredaPintoZoriel.Application.Commands.CreateTicket;
using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Application.Queries.GetAllTickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab10BarredaPintoZoriel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TicketCreateDTo dto)
    {
        await _mediator.Send(new CreateTicketCommand(dto));
        return Ok(new { message = "Ticket creado correctamente." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(result);
    }
}