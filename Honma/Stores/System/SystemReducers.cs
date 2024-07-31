using Fluxor;

namespace Honma.Stores;

public static class SystemReducers
{
	[ReducerMethod]
	public static SystemState Reduce(SystemState state, SystemsUpdated action) => state with
	{
		Systems = action.Systems,
		TotalSystems = action.TotalSystems
	};

	[ReducerMethod]
	public static SystemState Reduce(SystemState state, SystemUpdated action) => state with
	{
		System = action.System
	};

	[ReducerMethod]
	public static SystemState Reduce(SystemState state, SystemWaypointsUpdated action) => state with
	{
		Waypoints = action.Waypoints,
		TotalWaypoints = action.TotalWaypoints
	};
}