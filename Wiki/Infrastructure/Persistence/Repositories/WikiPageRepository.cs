using Application.Common.Models;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal class WikiPageRepository : BaseRepository<WikiPage>, IWikiPageRepository
{
    public WikiPageRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    
    public Task<PaginatedList<WikiPage>> SearchAsync(string query, int pageNumber, int pageSize)
    {
        var queryable = _dbContext.WikiPages.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(query))
        {
            queryable = queryable.Where(p => EF.Functions.ILike(p.Title, $"%{query}%"));
        } 
        
        return queryable.ToPaginatedListAsync(pageNumber, pageSize);
    }
}