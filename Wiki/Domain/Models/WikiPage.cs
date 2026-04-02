namespace Domain.Models;

public class WikiPage : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    private WikiPage() { }

    public WikiPage(string title, string content)
    {
        Title = title;
        Content = content;
    }
}