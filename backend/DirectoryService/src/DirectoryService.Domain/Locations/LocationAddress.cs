using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Locations;

public sealed record LocationAddress
{
    private const int MaxCountryLength = 100;
    private const int MaxRegionLength = 100;
    private const int MaxCityLength = 100;
    private const int MaxStreetLength = 200;
    private const int MaxHouseLength = 20;
    private const int MaxBuildingLength = 20;
    private const int MaxApartmentLength = 20;
    private const int MaxPostalCodeLength = 20;

    private static readonly Regex _postalCodeRegex =
        new(@"^[0-9A-Za-z\- ]{3,20}$", RegexOptions.Compiled);

    public string Country { get; }

    public string? Region { get; }

    public string City { get; }

    public string Street { get; }

    public string HouseNumber { get; }

    public string? Building { get; }

    public string? Apartment { get; }

    public string? PostalCode { get; }

    private LocationAddress(
        string country,
        string? region,
        string city,
        string street,
        string houseNumber,
        string? building,
        string? apartment,
        string? postalCode)
    {
        Country = country;
        Region = region;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        Building = building;
        Apartment = apartment;
        PostalCode = postalCode;
    }

    public static Result<LocationAddress, string> Create(
        string country,
        string city,
        string street,
        string houseNumber,
        string? region = null,
        string? building = null,
        string? apartment = null,
        string? postalCode = null)
    {
        country = Normalize(country);
        city = Normalize(city);
        street = Normalize(street);
        houseNumber = Normalize(houseNumber);
        region = Normalize(region);
        building = Normalize(building);
        apartment = Normalize(apartment);
        postalCode = Normalize(postalCode);

        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<LocationAddress, string>("Country is required");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<LocationAddress, string>("City is required");

        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<LocationAddress, string>("Street is required");

        if (string.IsNullOrWhiteSpace(houseNumber))
            return Result.Failure<LocationAddress, string>("House number is required");

        if (country.Length > MaxCountryLength)
            return Fail("Country", MaxCountryLength);

        if (city.Length > MaxCityLength)
            return Fail("City", MaxCityLength);

        if (street.Length > MaxStreetLength)
            return Fail("Street", MaxStreetLength);

        if (houseNumber.Length > MaxHouseLength)
            return Fail("House number", MaxHouseLength);

        if (!string.IsNullOrEmpty(region) && region.Length > MaxRegionLength)
            return Fail("Region", MaxRegionLength);

        if (!string.IsNullOrEmpty(building) && building.Length > MaxBuildingLength)
            return Fail("Building", MaxBuildingLength);

        if (!string.IsNullOrEmpty(apartment) && apartment.Length > MaxApartmentLength)
            return Fail("Apartment", MaxApartmentLength);

        if (!string.IsNullOrEmpty(postalCode))
        {
            if (postalCode.Length > MaxPostalCodeLength)
                return Fail("PostalCode", MaxPostalCodeLength);

            if (!_postalCodeRegex.IsMatch(postalCode))
                return "Postal code has invalid format";
        }

        return new LocationAddress(
            country,
            region,
            city,
            street,
            houseNumber,
            building,
            apartment,
            postalCode);
    }

    private static string Normalize(string? value) =>
        string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();

    private static Result<LocationAddress, string> Fail(string field, int max) =>
        $"{field} cannot exceed {max} characters";
}
