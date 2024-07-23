using Fluxor;
using Honma.Actions;

namespace Honma.Stores.Faction;

public static class FactionReducers
{
    [ReducerMethod]
    public static FactionState Reduce(FactionState state, FactionsUpdated action)
    {
        return new FactionState
        {
            Factions = action.Factions
        };
    }
}