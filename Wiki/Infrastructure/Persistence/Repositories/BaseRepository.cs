using Application.Common.Models;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Extensions;

namespace Infrastructure.Persistence.Repositories;

internal abstract class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        
    public virtual async Task<PaginatedList<T>> ListAsync(int pageNumber, int pageSize) 
        => await _dbContext.Set<T>().ToPaginatedListAsync(pageNumber, pageSize);
    
    public virtual async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public virtual Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return _dbContext.SaveChangesAsync();
    }
}