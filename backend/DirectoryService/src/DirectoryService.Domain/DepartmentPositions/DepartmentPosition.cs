using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.DepartmentPositions;

public sealed class DepartmentPosition(DepartmentId departmentId, PositionId positionId)
{
    public DepartmentPositionId Id { get; private set; } = new DepartmentPositionId(Guid.NewGuid());

    public DepartmentId DepartmentId { get; private set; } = departmentId;

    public PositionId PositionId { get; private set; } = positionId;
}
