using Fluxor;
using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record SystemState
{
    public List<SystemDto> Systems { get; init; } = [];

    public Pagination SystemsPagination { get; init; } = new();

    public SystemDto? System { get; init; }

    public List<Waypoint> Waypoints { get; init; } = [];

    public Pagination WaypointsPagination { get; init; } = new();
}