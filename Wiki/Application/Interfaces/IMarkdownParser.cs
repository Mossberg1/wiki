namespace Application.Interfaces;

public interface IMarkdownParser
{
    string ToHtml(string markdown);
}