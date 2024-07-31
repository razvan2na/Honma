using Fluxor;

namespace Honma.Stores;

public static class FactionReducers
{
    [ReducerMethod]
    public static FactionState Reduce(FactionState state, FactionsUpdated action) => new()
    {
        Factions = action.Factions
    };
}