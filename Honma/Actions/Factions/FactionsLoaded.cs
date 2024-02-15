using Fluxor;
using Honma.Models;
using Honma.States;

namespace Honma.Actions;

public readonly record struct FactionsLoaded(IReadOnlyList<Faction> Factions);

public class FactionsLoadedHandler
{
    [ReducerMethod]
    public static FactionsState Reduce(FactionsState state, FactionsLoaded action) => new()
    {
        Factions = action.Factions
    };
}