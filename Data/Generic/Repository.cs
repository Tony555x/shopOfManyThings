using Microsoft.EntityFrameworkCore;
using ShopOfManyThings.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync<T>(object id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
