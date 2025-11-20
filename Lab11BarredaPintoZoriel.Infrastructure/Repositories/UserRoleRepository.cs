using Lab11BarredaPintoZoriel.Domain.Repositories;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

namespace Lab11BarredaPintoZoriel.Infrastructure.Repositories;

public class UserRoleRepository :  GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(dbContextApi context) :  base(context) {}
    
}