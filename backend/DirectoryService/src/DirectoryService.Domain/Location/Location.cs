using CSharpFunctionalExtensions;
using DirectoryService.Domain.Department;
using DirectoryService.Domain.Location.ValueObjects;

namespace DirectoryService.Domain.Location;

public class Location
{
    private readonly List<DepartmentLocation> _departments = [];

    public Guid Id { get; private set; }

    public LocationName Name { get; private set; }

    public LocationAddress Address { get; private set; }

    public LocationTimezone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyCollection<DepartmentLocation> Departments => _departments;

    private Location(Guid id, LocationName name, LocationAddress address, LocationTimezone timezone)
    {
        Id = id;
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Location, string> Create(LocationName name, LocationAddress address, LocationTimezone tz)
    {
        return new Location(Guid.NewGuid(), name, address, tz);
    }
}
