using Lab11BarredaPintoZoriel.Domain.Repositories;
using Lab11BarredaPintoZoriel.Infrastructure.Models;

namespace Lab11BarredaPintoZoriel.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Response> Responses { get; }
    IGenericRepository<Ticket> Tickets { get; }
    IGenericRepository<User> Users { get; }
    IGenericRepository<Role> Roles { get; }
    IGenericRepository<UserRole> UserRoles { get; }

    Task<int> CompleteAsync();
}
