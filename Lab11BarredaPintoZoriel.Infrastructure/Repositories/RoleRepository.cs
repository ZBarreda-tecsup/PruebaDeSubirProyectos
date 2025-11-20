using Lab11BarredaPintoZoriel.Domain.Repositories;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

namespace Lab11BarredaPintoZoriel.Infrastructure.Repositories;

public class RoleRepository :  GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(dbContextApi context) :  base(context) {}
    
}