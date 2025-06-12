using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository
{
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<T?> GetByIdAsync<T>(object id) where T : class;
    Task AddAsync<T>(T entity) where T : class;
    Task UpdateAsync<T>(T entity) where T : class;
    Task DeleteAsync<T>(T entity) where T : class;
    Task SaveChangesAsync();
}
