using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab11BarredaPintoZoriel.Application.Queries.GetAllRoles;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RoleDTo>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Roles.GetAll();

        var roles = await query
            .Include(r => r.UserRoles)
            .ThenInclude(ur => ur.User)
            .Select(r => new RoleDTo
            {
                id = r.RoleId,
                RoleName = r.RoleName,
                Users = r.UserRoles.Select(ur => new UserSimpleDTo
                {
                    UserName = ur.User.Username,
                    Email = ur.User.Email
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        return roles;
    }
}