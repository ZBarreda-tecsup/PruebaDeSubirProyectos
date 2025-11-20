using Lab10BarredaPintoZoriel.Application.Commands.CreateRole;
using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Application.Queries.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11BarredaPintoZoriel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleCreateDTo dto)
    {
        var id = await _mediator.Send(new CreateRoleCommand(dto));
        return Ok(new { RoleId = id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }
}