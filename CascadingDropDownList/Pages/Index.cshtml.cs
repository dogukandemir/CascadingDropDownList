using CascadingDropDownList.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CascadingDropDownList.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, ILocationService locationService)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}