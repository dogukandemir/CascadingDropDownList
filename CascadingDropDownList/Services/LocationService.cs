using CascadingDropDownList.Models;

namespace CascadingDropDownList.Services;

public class LocationService : ILocationService
{
    private readonly List<Country> _countries = new();
    private readonly List<Region> _regions = new();
    private readonly List<City> _cities = new();

    public LocationService()
    {
        var regionId = 1;
        var cityId = 1;
        for (var countryIndex = 0; countryIndex < 3; countryIndex++)
        {
            var countryId = countryIndex + 1;
            _countries.Add(new Country
            {
                Id = countryId,
                Name = $"Country {countryId}"
            });

            for (var regionIndex = 0; regionIndex < 3; regionIndex++, regionId++)
            {
                _regions.Add(new Region
                {
                    Id = regionId,
                    Name = $"Region {regionId} - {countryId}",
                    CountryId = countryId
                });

                for (var cityIndex = 0; cityIndex < 3; cityIndex++, cityId++)
                {
                    _cities.Add(new City
                    {
                        Id = cityId,
                        Name = $"City {cityId} - {regionId} - {countryId}",
                        RegionId = regionId
                    });
                }
            }
        }
    }

    public async Task<List<Country>> GetCountries()
    {
        await Task.Delay(1000);
        return _countries;
    }

    public async Task<List<Region>> GetRegions(int countryId)
    {
        await Task.Delay(1000);
        return _regions.Where(region => region.CountryId == countryId).ToList();
    }

    public async Task<List<City>> GetCities(int regionId)
    {
        await Task.Delay(1000);
        return _cities.Where(city => city.RegionId == regionId).ToList();
    }
}