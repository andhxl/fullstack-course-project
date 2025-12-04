namespace DirectoryService.Domain.Department;

public sealed class DepartmentPosition(Guid departmentId, Guid positionId)
{
    public Guid DepartmentId { get; } = departmentId;

    public Guid PositionId { get; } = positionId;
}
