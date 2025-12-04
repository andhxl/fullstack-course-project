using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location.ValueObjects;

public sealed record LocationName
{
    public const int MinLength = 3;
    public const int MaxLength = 120;

    public string Value { get; }

    private LocationName(string value) => Value = value;

    public static Result<LocationName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Location name is required";

        if (value.Length is < MinLength or > MaxLength)
            return $"Location name must be {MinLength}–{MaxLength} characters";

        return new LocationName(value);
    }
}
