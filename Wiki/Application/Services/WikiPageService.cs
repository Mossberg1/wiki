using Application.Common.Dtos.WikiPageDtos;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services;

internal class WikiPageService : IWikiPageService
{
    private readonly IWikiPageRepository _wikiPageRepository;
    private const int _pageSize = 24;

    public WikiPageService(IWikiPageRepository wikiPageRepository)
    {
        _wikiPageRepository = wikiPageRepository;
    }

    public async Task<PaginatedList<WikiPageDto>> ListAsync(int pageNumber)
    {
        var pages = await _wikiPageRepository.ListAsync(pageNumber, _pageSize);
        var mappedPages = pages.Items.Select(WikiPageDto.FromEntity).ToList();
        
        return new PaginatedList<WikiPageDto>(mappedPages, pages.TotalCount, pageNumber, _pageSize);
    }
    
    public async Task<PaginatedList<WikiPageDto>> SearchAsync(string query, int pageNumber)
    {
        var pages = await _wikiPageRepository.SearchAsync(query, pageNumber, _pageSize);
        var mappedPages = pages.Items.Select(WikiPageDto.FromEntity).ToList();
        
        return new PaginatedList<WikiPageDto>(mappedPages, pages.TotalCount, pageNumber, _pageSize);
    }
}