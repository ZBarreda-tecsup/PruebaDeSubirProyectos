using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllUserRole;

public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<UserRoleDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserRolesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserRoleDTo>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.UserRoles.GetAll();

        var userRoles = await query
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .Select(ur => new UserRoleDTo
            {
                User = new UserSimpleDTo
                {
                    UserName = ur.User.Username,
                    Email = ur.User.Email
                },
                Role = new RoleUserDTo
                {
                    RoleName = ur.Role.RoleName
                }
            })
            .ToListAsync(cancellationToken);

        return userRoles;
    }
}