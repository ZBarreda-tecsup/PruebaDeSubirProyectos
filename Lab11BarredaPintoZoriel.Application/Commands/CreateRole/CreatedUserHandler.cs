using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Commands.CreateRole;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = request.Role.RoleName
        };

        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.CompleteAsync();

        return role.RoleId;
    }
}