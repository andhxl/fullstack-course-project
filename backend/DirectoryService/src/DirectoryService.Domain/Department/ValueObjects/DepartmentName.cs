using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department.ValueObjects;

public sealed record DepartmentName
{
    public string Value { get; }

    private DepartmentName(string value) => Value = value;

    public static Result<DepartmentName, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Department name is required";

        if (value.Length is < 3 or > 150)
            return "Department name must be 3–150 characters";

        return new DepartmentName(value);
    }
}
