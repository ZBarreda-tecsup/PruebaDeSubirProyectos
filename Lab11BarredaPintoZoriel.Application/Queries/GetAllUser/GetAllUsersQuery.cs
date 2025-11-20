using Lab11BarredaPintoZoriel.Application.DTos;
using MediatR;

namespace Lab10BarredaPintoZoriel.Application.Queries.GetAllUser;


public record GetAllUsersQuery() : IRequest<IEnumerable<UserDTo>>;