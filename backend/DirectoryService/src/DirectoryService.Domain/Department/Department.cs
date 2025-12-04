using CSharpFunctionalExtensions;
using DirectoryService.Domain.Department.ValueObjects;

namespace DirectoryService.Domain.Department;

public sealed class Department
{
    private readonly List<DepartmentLocation> _locations = [];
    private readonly List<DepartmentPosition> _positions = [];

    public Guid Id { get; private set; }

    public DepartmentName Name { get; private set; }

    public DepartmentIdentifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    private Department(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Guid? parentId,
        DepartmentPath path,
        short depth)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Department, string> Create(
        string name,
        string identifier,
        Guid? parentId,
        string path,
        short depth,
        bool isActive)
    {
        var nameResult = DepartmentName.Create(name);
        if (nameResult.IsFailure)
            return nameResult.Error;

        var identifierResult = DepartmentIdentifier.Create(identifier);
        if (identifierResult.IsFailure)
            return identifierResult.Error;

        var pathResult = DepartmentPath.Create(path);
        if (pathResult.IsFailure)
            return pathResult.Error;

        return new Department(
            nameResult.Value,
            identifierResult.Value,
            parentId,
            pathResult.Value,
            depth,
            isActive);
    }
}
