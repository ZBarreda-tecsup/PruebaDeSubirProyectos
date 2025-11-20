using Lab10BarredaPintoZoriel.Application.Queries.GetAllUser;
using Lab11BarredaPintoZoriel.Application.Commands.CreateUser;
using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab10BarredaPintoZoriel.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDTo dto)
        {
            var id = await _mediator.Send(new CreateUserCommand(dto));
            return Ok(new { UserId = id });
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
    }