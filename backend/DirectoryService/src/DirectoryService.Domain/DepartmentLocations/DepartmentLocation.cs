using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.DepartmentLocations;

public sealed class DepartmentLocation(DepartmentId departmentId, LocationId locationId)
{
    public DepartmentLocationId Id { get; private set; } = new DepartmentLocationId(Guid.NewGuid());

    public DepartmentId DepartmentId { get; private set; } = departmentId;

    public LocationId LocationId { get; private set; } = locationId;
}
