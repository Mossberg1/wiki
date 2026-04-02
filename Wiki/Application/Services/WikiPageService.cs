using Application.Common.Dtos.WikiPageDtos;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services;

internal class WikiPageService : IWikiPageService
{
    private readonly IWikiPageRepository _wikiPageRepository;
    private readonly IMarkdownParser _markdownParser;
    private const int _pageSize = 24;

    public WikiPageService(IWikiPageRepository wikiPageRepository, IMarkdownParser markdownParser)
    {
        _wikiPageRepository = wikiPageRepository;
        _markdownParser = markdownParser;
    }

    public async Task<int> CreateAsync(WikiPageCreateDto dto)
    {
        var wikiPage = WikiPageCreateDto.ToEntity(dto);
        await _wikiPageRepository.CreateAsync(wikiPage);

        return wikiPage.Id;
    }

    public async Task<WikiPageDetailsDto?> GetAsync(int id)
    {
        var page = await _wikiPageRepository.GetByIdAsync(id);
        if (page == null)
        {
            return null;
        }
        
        var htmlContent = _markdownParser.ToHtml(page.Content);
        
        return WikiPageDetailsDto.FromEntity(page, htmlContent);
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