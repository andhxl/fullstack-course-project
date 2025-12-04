using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations;

public sealed record LocationTimezone
{
    public string Value { get; }

    private LocationTimezone(string value)
    {
        Value = value;
    }

    public static Result<LocationTimezone, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Timezone is required";

        string normalized = value.Trim();

        if (!IsValidSystemTimeZoneId(normalized))
            return $"Timezone '{normalized}' is not recognized by the system";

        return new LocationTimezone(normalized);
    }

    public TimeZoneInfo ToTimeZoneInfo() =>
        TimeZoneInfo.FindSystemTimeZoneById(Value);

    private static bool IsValidSystemTimeZoneId(string id) =>
        TimeZoneInfo.TryFindSystemTimeZoneById(id, out _);
}
