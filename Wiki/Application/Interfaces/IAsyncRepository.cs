using Application.Common.Models;
using Domain.Models;

namespace Application.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<PaginatedList<T>> ListAsync(int pageNumber, int pageSize);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}