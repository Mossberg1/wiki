using Domain.Models;

namespace Application.Common.Dtos.WikiPageDtos;

public class WikiPageDto
{
    public int Id { get; }
    public string Title { get; }
    public DateTime CreatedAt { get; }

    public WikiPageDto(int id, string title, DateTime createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }

    public static WikiPageDto FromEntity(WikiPage entity) 
        => new WikiPageDto(entity.Id, entity.Title, entity.CreatedAt);
}


