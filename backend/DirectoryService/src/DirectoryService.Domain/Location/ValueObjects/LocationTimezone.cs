using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Location.ValueObjects;

public sealed record LocationTimezone
{
    public string Value { get; }

    private LocationTimezone(string value) => Value = value;

    public static Result<LocationTimezone, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Timezone required";

        if (!value.Contains('/', StringComparison.Ordinal))
            return "Timezone must be valid IANA code (e.g. Europe/Moscow).";

        return new LocationTimezone(value);
    }
}
