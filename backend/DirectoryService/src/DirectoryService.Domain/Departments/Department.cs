using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations;
using DirectoryService.Domain.DepartmentPositions;

namespace DirectoryService.Domain.Departments;

public sealed class Department
{
    private readonly List<DepartmentLocation> _locations = [];
    private readonly List<DepartmentPosition> _positions = [];

    public DepartmentId Id { get; private set; }

    public DepartmentId? ParentId { get; private set; }

    public Department? Parent { get; private set; }

    public IList<Department> Children { get; private set; } = [];

    public DepartmentName Name { get; private set; }

    public DepartmentIdentifier Identifier { get; private set; }

    public DepartmentPath Path { get; private set; }

    public int Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    private Department(
        DepartmentId id,
        DepartmentId? parentId,
        DepartmentName name,
        DepartmentIdentifier identifier,
        DepartmentPath path,
        int depth,
        List<DepartmentLocation> locations)
    {
        Id = id;
        ParentId = parentId;
        Name = name;
        Identifier = identifier;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        _locations = locations;
    }

    public static Result<Department, string> CreateParent(
        DepartmentName name,
        DepartmentIdentifier identifier,
        IEnumerable<DepartmentLocation> locations,
        DepartmentId? id = null)
    {
        var locationsList = locations.ToList();

        if (locationsList.Count == 0)
            return "Department locations must contain at least one location";

        var path = DepartmentPath.CreateParent(identifier);

        return new Department(
            id ?? new DepartmentId(Guid.NewGuid()),
            null,
            name,
            identifier,
            path,
            0,
            locationsList);
    }

    public static Result<Department, string> CreateChild(
        Department parent,
        DepartmentName name,
        DepartmentIdentifier identifier,
        IEnumerable<DepartmentLocation> locations,
        DepartmentId? id = null)
    {
        var locationsList = locations.ToList();

        if (locationsList.Count == 0)
            return "Department locations must contain at least one location";

        var path = parent.Path.CreateChild(identifier);

        return new Department(
            id ?? new DepartmentId(Guid.NewGuid()),
            parent.Id,
            name,
            identifier,
            path,
            parent.Depth + 1,
            locationsList);
    }
}
