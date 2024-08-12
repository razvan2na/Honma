using Fluxor;

namespace Honma.Stores;

public static class ShipReducers
{
    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipsUpdated action)
    {
        return new ShipState
        {
            Ships = action.Ships,
            Pagination = action.Pagination
        };
    }

    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipUpdated action)
    {
        return state with
        {
            Ship = action.Ship
        };
    }

    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipNavUpdated action)
    {
        if (state.Ship is null)
        {
            return state;
        }

        return state with
        {
            Ship = state.Ship.Value with { Nav = action.Nav }
        };
    }

    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipFuelUpdated action)
    {
        if (state.Ship is null)
        {
            return state;
        }

        return state with
        {
            Ship = state.Ship.Value with { Fuel = action.Fuel }
        };
    }

    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipCooldownUpdated action)
    {
        if (state.Ship is null)
        {
            return state;
        }

        return state with
        {
            Ship = state.Ship.Value with { Cooldown = action.Cooldown }
        };
    }

    [ReducerMethod]
    public static ShipState Reduce(ShipState state, ShipCargoUpdated action)
    {
        if (state.Ship is null)
        {
            return state;
        }

        return state with
        {
            Ship = state.Ship.Value with { Cargo = action.Cargo }
        };
    }
}