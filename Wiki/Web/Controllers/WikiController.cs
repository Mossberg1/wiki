using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class WikiController : Controller
{
    private readonly IWikiPageService _wikiPageService;

    public WikiController(IWikiPageService wikiPageService)
    {
        _wikiPageService = wikiPageService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] string? query, [FromQuery] int page = 1)
    {
        if (!string.IsNullOrEmpty(query))
        {
            return View(await _wikiPageService.SearchAsync(query, page));
        }

        return View(await _wikiPageService.ListAsync(page));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Page(int id)
    {
        var page = await _wikiPageService.GetAsync(id);
        return View(page);
    }
}