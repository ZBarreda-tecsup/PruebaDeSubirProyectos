using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab11BarredaPintoZoriel.Application.Commands.CreateUserRole;

public sealed record CreateUserRoleCommand(UserRoleCreateDTo Dto) : IRequest<Unit>;
