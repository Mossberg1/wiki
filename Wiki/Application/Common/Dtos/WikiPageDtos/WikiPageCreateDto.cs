using Domain.Models;

namespace Application.Common.Dtos.WikiPageDtos;

public class WikiPageCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    public WikiPageCreateDto() { }

    public WikiPageCreateDto(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public static WikiPage ToEntity(WikiPageCreateDto dto) => new (dto.Title, dto.Content);
}