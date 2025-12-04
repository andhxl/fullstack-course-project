using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentPositions;

namespace DirectoryService.Domain.Positions;

public sealed class Position
{
    private readonly List<DepartmentPosition> _departments = [];

    public PositionId Id { get; private set; }

    public PositionName Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyCollection<DepartmentPosition> Departments => _departments;

    private Position(PositionName name, string? description)
    {
        Id = new PositionId(Guid.NewGuid());
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Position, string> Create(PositionName name, string? description)
    {
        if (!string.IsNullOrEmpty(description) && description.Length > 1000)
            return "Description too long";

        return new Position(name, description);
    }
}
