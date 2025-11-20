using Lab10BarredaPintoZoriel.Application.Queries.GetAllUserRole;
using Lab11BarredaPintoZoriel.Application.Commands.CreateUserRole;
using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11BarredaPintoZoriel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllUserRolesQuery());
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRoleCreateDTo dto)
    {
        await _mediator.Send(new CreateUserRoleCommand(dto));
        return NoContent();
    }
}