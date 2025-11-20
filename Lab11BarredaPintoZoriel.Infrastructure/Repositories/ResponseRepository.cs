using Lab11BarredaPintoZoriel.Domain.Repositories;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;

namespace Lab11BarredaPintoZoriel.Infrastructure.Repositories;

public class ResponseRepository :  GenericRepository<Response>, IResponseRepository
{
    public ResponseRepository(dbContextApi context) :  base(context) {}
    
}