using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

internal static class PaginationExtensions
{
    public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> query,
        int pageIndex, 
        int pageSize
    )
    {
        var count = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}