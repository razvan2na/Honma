using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record SystemState
{
	public IReadOnlyCollection<SystemDto> Systems { get; init; } = [];

	public int TotalSystems { get; init; }

	public SystemDto? System { get; init; }

	public IReadOnlyCollection<Waypoint> Waypoints { get; init; } = [];

	public int TotalWaypoints { get; init; }
}