using Domain.Models;

namespace Application.Common.Dtos.WikiPageDtos;

public class WikiPageDetailsDto
{
    public int Id { get; }
    public string Title { get; }
    public string Content { get; }
    public DateTime CreatedAt { get; }

    public WikiPageDetailsDto(int id, string title, string content, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt;
    }
    
    public static WikiPageDetailsDto FromEntity(WikiPage entity) 
        => new WikiPageDetailsDto(entity.Id, entity.Title, entity.Content, entity.CreatedAt);

    public static WikiPageDetailsDto FromEntity(WikiPage entity, string htmlContent) 
        => new WikiPageDetailsDto(entity.Id, entity.Title, htmlContent, entity.CreatedAt);
}