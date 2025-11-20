using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lab11BarredaPintoZoriel.Application.Commands.CreateUserRole;

public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<Unit> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        
        var userExists = await _unitOfWork.Users
            .GetAll()
            .AnyAsync(u => u.UserId == dto.UserId, cancellationToken);
        
        if (!userExists)
            throw new ApplicationException("User not found");
            
        var roleExists = await _unitOfWork.Roles
            .GetAll()
            .AnyAsync(r => r.RoleId == dto.RoleId, cancellationToken);

        if (!roleExists)
            throw new ApplicationException("Role not found");
        
        var alreadyAssigned = await _unitOfWork.UserRoles
            .GetAll()
            .AnyAsync(ur => ur.UserId == dto.UserId && ur.RoleId == dto.RoleId, cancellationToken);

        if (alreadyAssigned)
            throw new ApplicationException("This user already has that role assigned");
        
        var userRole = new Infrastructure.Models.UserRole
        {
            UserId = dto.UserId,
            RoleId = dto.RoleId,
            AssignedAt = dto.CreateAt?.ToUniversalTime() ?? DateTime.UtcNow
        };

        await _unitOfWork.UserRoles.AddAsync(userRole);
        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}