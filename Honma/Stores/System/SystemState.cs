using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record SystemState
{
	public SystemDto? System { get; init; }

	public Waypoint? Waypoint { get; init; }
}