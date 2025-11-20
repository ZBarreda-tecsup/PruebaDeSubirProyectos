using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllUser;

public class GetAllUsersHandler: IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDTo>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Users.GetAll();

        return await query
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Select(u => new UserDTo
            {
                Id = u.UserId,
                UserName = u.Username,
                Email = u.Email,
                QuantityTickets = u.Tickets.Count(),
                role = u.UserRoles.Select(ur => new RoleUserDTo
                {
                    RoleName = ur.Role.RoleName
                }).FirstOrDefault()!
            })
            .ToListAsync(cancellationToken);
    }
}