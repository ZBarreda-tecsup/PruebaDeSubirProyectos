using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateRole;

public record CreateRoleCommand(RoleCreateDTo Role) : IRequest<Guid>;