using Application.Interfaces;
using Markdig;

namespace Infrastructure.Parsers;

public class MarkdigParser : IMarkdownParser
{
    public string ToHtml(string markdown)
    {
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .Build();

        return Markdown.ToHtml(markdown, pipeline);
    }
}



