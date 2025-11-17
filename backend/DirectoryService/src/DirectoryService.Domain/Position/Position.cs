using CSharpFunctionalExtensions;
using DirectoryService.Domain.Department;
using DirectoryService.Domain.Position.ValueObjects;

namespace DirectoryService.Domain.Position;

public class Position
{
    private readonly List<DepartmentPosition> _departments = [];

    public Guid Id { get; private set; }

    public PositionName Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyCollection<DepartmentPosition> Departments => _departments;

    private Position(Guid id, PositionName name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Position, string> Create(PositionName name, string? description)
    {
        if (description?.Length > 1000)
            return "Description too long";

        return new Position(Guid.NewGuid(), name, description);
    }
}
