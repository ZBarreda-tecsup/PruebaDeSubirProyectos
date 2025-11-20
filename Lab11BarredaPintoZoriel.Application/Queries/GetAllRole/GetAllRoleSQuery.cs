using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab11BarredaPintoZoriel.Application.Queries.GetAllRoles;
    
public record GetAllRolesQuery : IRequest<IEnumerable<RoleDTo>>;
