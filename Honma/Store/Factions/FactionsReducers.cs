using Fluxor;

namespace Honma.Store;

public static class FactionsReducers
{
    [ReducerMethod]
    public static FactionsState ReduceFactionsLoaded(FactionsState state, FactionsLoaded action)
    {
        return new FactionsState() { Factions = action.Factions };
    }
}