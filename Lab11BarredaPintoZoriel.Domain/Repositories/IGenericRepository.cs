using System.Linq.Expressions;

namespace Lab11BarredaPintoZoriel.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    
    IQueryable<T> GetAll();
    
    Task<T?> GetById(Guid id);
    void Update(T entity);
    void Delete(T entity);
}