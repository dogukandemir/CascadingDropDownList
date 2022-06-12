using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDropDownList.Pages.Shared;

public class SelectLocationViewModel
{
    private static HttpClient _httpClient = new();

    public SelectLocationViewModel()
    {

    }

    public List<SelectListItem> Countries { get; set; } = new();
    public string SelectedCountry { get; set; }
    public List<SelectListItem> Regions { get; set; } = new();
    public string SelectedRegion { get; set; }
    public List<SelectListItem> Cities { get; set; } = new();
    public string SelectedCity { get; set; }

    public static async Task<HtmlString> Populate(SelectLocationViewModel viewModel, HttpRequest request, IUrlHelper urlHelper)
    {
        var requestBaseUrl = $"{request.Scheme}://{request.Host.Value}";
        var requestUrl = urlHelper.Action("Populate", "LocationView", new
        {
            countryId = viewModel?.SelectedCountry,
            regionId = viewModel?.SelectedRegion,
            cityId = viewModel?.SelectedCity
        });

        var response = await _httpClient.GetStringAsync($"{requestBaseUrl}{requestUrl}");

        return new HtmlString(response);
    }
}