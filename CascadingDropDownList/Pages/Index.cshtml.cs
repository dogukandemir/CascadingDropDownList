using CascadingDropDownList.Pages.Shared;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CascadingDropDownList.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public SelectLocationViewModel SelectLocationViewModel { get; set; }

    public HtmlString SelectLocationViewPlaceholder { get; set; }

    public async Task OnGet()
    {
        SelectLocationViewPlaceholder = await SelectLocationViewModel.Populate(SelectLocationViewModel, Request, Url);
    }

    public async Task OnPost()
    {
        SelectLocationViewPlaceholder = await SelectLocationViewModel.Populate(SelectLocationViewModel, Request, Url);
    }
}