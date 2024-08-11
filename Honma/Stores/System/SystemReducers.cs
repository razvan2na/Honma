using Fluxor;

namespace Honma.Stores;

public static class SystemReducers
{
    [ReducerMethod]
    public static SystemState Reduce(SystemState state, SystemsUpdated action)
    {
        return state with
        {
            Systems = action.Systems,
            SystemsPagination = action.Pagination
        };
    }

    [ReducerMethod]
    public static SystemState Reduce(SystemState state, SystemUpdated action)
    {
        return state with
        {
            System = action.System
        };
    }

    [ReducerMethod]
    public static SystemState Reduce(SystemState state, SystemWaypointsUpdated action)
    {
        return state with
        {
            Waypoints = action.Waypoints,
            WaypointsPagination = action.Pagination
        };
    }
}