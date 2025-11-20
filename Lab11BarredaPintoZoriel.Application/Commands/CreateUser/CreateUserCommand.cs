using Lab11BarredaPintoZoriel.Application.DTos;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using MediatR;

namespace Lab11BarredaPintoZoriel.Application.Commands.CreateUser;

public record CreateUserCommand(UserCreateDTo User) : IRequest<Guid>;