using Application.Common.Models;

namespace Application.Interfaces;

public interface ISearchableRepository<T>
{
    Task<PaginatedList<T>> SearchAsync(string query, int pageNumber, int pageSize);
}