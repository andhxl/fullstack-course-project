using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Department.ValueObjects;

public sealed record DepartmentIdentifier
{
    private static readonly Regex _latinRegex = new(@"^[A-Za-z]+$", RegexOptions.Compiled);

    public string Value { get; }

    private DepartmentIdentifier(string value) => Value = value;

    public static Result<DepartmentIdentifier, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "Department identifier is required";

        if (value.Length is < 3 or > 150)
            return "Department identifier must be 3–150 characters";

        if (!_latinRegex.IsMatch(value))
            return "Department identifier must contain only Latin letters";

        return new DepartmentIdentifier(value);
    }
}
