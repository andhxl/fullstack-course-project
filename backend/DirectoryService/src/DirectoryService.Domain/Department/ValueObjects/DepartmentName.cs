using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department.ValueObjects;

public sealed record DepartmentName
{
    public const int MinLength = 3;
    public const int MaxLength = 150;

    public string Value { get; }

    private DepartmentName(string value) => Value = value;

    public static Result<DepartmentName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Department name is required";

        if (value.Length is < MinLength or > MaxLength)
            return $"Department name must be {MinLength}–{MaxLength} characters";

        return new DepartmentName(value);
    }
}
