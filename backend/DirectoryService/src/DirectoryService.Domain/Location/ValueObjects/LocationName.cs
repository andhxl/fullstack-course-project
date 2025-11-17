using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location.ValueObjects;

public sealed record LocationName
{
    public string Value { get; }

    private LocationName(string value) => Value = value;

    public static Result<LocationName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Location name is required";

        if (value.Length is < 3 or > 120)
            return "Location name must be 3–120 characters";

        return new LocationName(value);
    }
}
