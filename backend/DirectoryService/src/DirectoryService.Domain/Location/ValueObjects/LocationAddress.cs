using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location.ValueObjects;

public sealed record LocationAddress
{
    public string Value { get; }

    private LocationAddress(string value) => Value = value;

    public static Result<LocationAddress, string> Create(string value)
    {
        return new LocationAddress(value);
    }
}
