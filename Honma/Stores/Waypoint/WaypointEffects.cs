using Fluxor;
using Honma.Data;
using Honma.Models;
using Honma.Utils;

namespace Honma.Stores;

public class WaypointEffects(ISpaceTradersClient client)
{
    [EffectMethod]
    public async Task Handle(WaypointLoad action, IDispatcher dispatcher)
    {
        var waypoint = (await client.GetWaypoint(action.SystemSymbol, action.WaypointSymbol)).Data;

        dispatcher.Dispatch(new WaypointUpdated(waypoint));

        if (waypoint.Traits.Any(trait => trait.Symbol == WaypointTraitSymbol.Shipyard.ToString().ToMacroCase()))
        {
            dispatcher.Dispatch(new ShipyardLoad(action.SystemSymbol, action.WaypointSymbol));
        }

        if (waypoint.Traits.Any(trait => trait.Symbol == WaypointTraitSymbol.Marketplace.ToString().ToMacroCase()))
        {
            dispatcher.Dispatch(new MarketLoad(action.SystemSymbol, action.WaypointSymbol));
        }
    }
}