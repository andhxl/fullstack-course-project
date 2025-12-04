using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public sealed record DepartmentPath
{
    private const char Separator = '.';

    public string Value { get; }

    private DepartmentPath(string value) => Value = value;

    public static Result<DepartmentPath, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Department path is required";

        return new DepartmentPath(value);
    }

    public static DepartmentPath CreateParent(DepartmentIdentifier identifier)
    {
        return new DepartmentPath(identifier.Value);
    }

    public DepartmentPath CreateChild(DepartmentIdentifier identifier)
    {
        return new DepartmentPath(Value + Separator + identifier.Value);
    }
}
