using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using MediatR;

namespace Lab11BarredaPintoZoriel.Application.Commands.CreateUser;

public class CreateUserHandler: IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.User;

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = dto.Username,
                PasswordHash = dto.Password,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
            };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return user.UserId;
    }
}