using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Position.ValueObjects;

public sealed record PositionName
{
    public string Value { get; }

    private PositionName(string value) => Value = value;

    public static Result<PositionName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Position name is required";

        if (value.Length is < 3 or > 100)
            return "Position name must be 3–100 characters";

        return new PositionName(value);
    }
}
