using CascadingDropDownList.Models;
using CascadingDropDownList.Services;
using Microsoft.AspNetCore.Mvc;

namespace CascadingDropDownList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [Route("GetCountries")]
    public async Task<List<Country>> GetCountries()
    {
        return await _locationService.GetCountries();
    }

    [Route("GetRegions")]
    public async Task<List<Region>> GetRegions(int countryId)
    {
        return await _locationService.GetRegions(countryId);
    }

    [Route("GetCities")]
    public async Task<List<City>> GetCities(int regionId)
    {
        return await _locationService.GetCities(regionId);
    }
}