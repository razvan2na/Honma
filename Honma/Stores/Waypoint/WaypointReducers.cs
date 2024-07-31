using Fluxor;

namespace Honma.Stores;

public static class WaypointReducers
{
	[ReducerMethod]
	public static WaypointState Reduce(WaypointState state, WaypointUpdated action) => state with
	{
		Waypoint = action.Waypoint
	};

	[ReducerMethod]
	public static WaypointState Reduce(WaypointState state, WaypointMarketUpdated action) => state with
	{
		Market = action.Market
	};

	[ReducerMethod]
	public static WaypointState Reduce(WaypointState state, WaypointShipyardUpdated action) => state with
	{
		Shipyard = action.Shipyard
	};

	[ReducerMethod]
	public static WaypointState Reduce(WaypointState state, WaypointJumpGateUpdated action) => state with
	{
		JumpGate = action.JumpGate
	};
}