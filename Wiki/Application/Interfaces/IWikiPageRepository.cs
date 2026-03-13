using Domain.Models;

namespace Application.Interfaces;

public interface IWikiPageRepository : IAsyncRepository<WikiPage>, ISearchableRepository<WikiPage>
{
    
}