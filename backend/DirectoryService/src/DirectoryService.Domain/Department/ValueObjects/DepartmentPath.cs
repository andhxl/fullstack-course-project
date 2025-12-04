using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Department.ValueObjects;

public sealed record DepartmentPath
{
    public string Value { get; }

    private DepartmentPath(string value) => Value = value;

    public static Result<DepartmentPath, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Department path is required";

        return new DepartmentPath(value);
    }
}
