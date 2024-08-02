using Fluxor;

namespace Honma.Stores;

public static class WaypointReducers
{
	[ReducerMethod]
	public static WaypointState Reduce(WaypointState state, WaypointUpdated action) => state with
	{
		Waypoint = action.Waypoint
	};
}