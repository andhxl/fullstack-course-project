namespace DirectoryService.Domain.Department;

public sealed class DepartmentLocation(Guid departmentId, Guid locationId)
{
    public Guid DepartmentId { get; } = departmentId;

    public Guid LocationId { get; } = locationId;
}
