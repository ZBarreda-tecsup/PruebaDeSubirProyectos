using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllUserRole;

public record GetAllUserRolesQuery() : IRequest<IEnumerable<UserRoleDTo>>;