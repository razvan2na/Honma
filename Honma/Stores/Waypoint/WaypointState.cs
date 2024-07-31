using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record WaypointState
{
	public Waypoint? Waypoint { get; init; }

	public Market? Market { get; init; }

	public Shipyard? Shipyard { get; init; }

	public JumpGate? JumpGate { get; init; }
}