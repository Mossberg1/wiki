using Application.Common.Dtos.WikiPageDtos;
using Application.Common.Models;

namespace Application.Interfaces;

public interface IWikiPageService
{
    Task<int> CreateAsync(WikiPageCreateDto dto);
    Task<WikiPageDetailsDto?> GetAsync(int id);
    Task<PaginatedList<WikiPageDto>> ListAsync(int pageNumber);
    Task<PaginatedList<WikiPageDto>> SearchAsync(string query, int pageNumber);
}