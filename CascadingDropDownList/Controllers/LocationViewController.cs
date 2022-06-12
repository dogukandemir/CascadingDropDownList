using CascadingDropDownList.Pages.Shared;
using CascadingDropDownList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadingDropDownList.Controllers;

[Route("[controller]")]
public class LocationViewController : Controller
{
    private readonly ILocationService _locationService;

    public LocationViewController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    [Route("Populate")]
    public async Task<IActionResult> Populate(string countryId = null, string regionId = null, string cityId = null)
    {
        var selectLocationViewModel = new SelectLocationViewModel();
        var countries = await _locationService.GetCountries();
        selectLocationViewModel.Countries = !string.IsNullOrEmpty(countryId) && int.TryParse(countryId, out var countryIdNumber)
            ? countries.Select(item =>
                new SelectListItem(item.Name, item.Id.ToString(), item.Id == countryIdNumber)).ToList()
            : countries.Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();

        if (!string.IsNullOrEmpty(countryId))
        {
            var regions = await _locationService.GetRegions(int.Parse(countryId));

            selectLocationViewModel.Regions =
                !string.IsNullOrEmpty(regionId) && int.TryParse(regionId, out var regionIdNumber)
                    ? regions.Select(item =>
                        new SelectListItem(item.Name, item.Id.ToString(), item.Id == regionIdNumber)).ToList()
                    : regions.Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();

            if (!string.IsNullOrEmpty(regionId))
            {
                var cities = await _locationService.GetCities(int.Parse(regionId));

                selectLocationViewModel.Cities =
                    !string.IsNullOrEmpty(cityId) && int.TryParse(cityId, out var cityIdNumber)
                        ? cities.Select(item =>
                            new SelectListItem(item.Name, item.Id.ToString(), item.Id == cityIdNumber)).ToList()
                        : cities.Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();
            }
        }

        return PartialView("_SelectLocationView", selectLocationViewModel);
    }
}