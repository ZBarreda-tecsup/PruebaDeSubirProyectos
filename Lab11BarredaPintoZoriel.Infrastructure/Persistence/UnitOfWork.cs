using Lab11BarredaPintoZoriel.Domain.Repositories;
using Lab11BarredaPintoZoriel.Infrastructure.Repositories;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

namespace Lab11BarredaPintoZoriel.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbContextApi _context;

        private IGenericRepository<Response>? _responses;
        private IGenericRepository<Ticket>? _tickets;
        private IGenericRepository<User>? _users;
        private IGenericRepository<Role>? _roles;
        private IGenericRepository<UserRole>? _userRoles;

        public UnitOfWork(dbContextApi context)
        {
            _context = context;
        }

        public IGenericRepository<Response> Responses => _responses ??= new GenericRepository<Response>(_context);
        public IGenericRepository<Ticket> Tickets => _tickets ??= new GenericRepository<Ticket>(_context);
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<Role> Roles => _roles ??= new GenericRepository<Role>(_context);
        public IGenericRepository<UserRole> UserRoles => _userRoles ??= new GenericRepository<UserRole>(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}