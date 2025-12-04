using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions;

public sealed record PositionName
{
    public const int MinLength = 3;
    public const int MaxLength = 100;

    public string Value { get; }

    private PositionName(string value) => Value = value;

    public static Result<PositionName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Position name is required";

        if (value.Length is < MinLength or > MaxLength)
            return $"Position name must be {MinLength}–{MaxLength} characters";

        return new PositionName(value);
    }
}
