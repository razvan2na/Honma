using Fluxor;
using Honma.Data;

namespace Honma.Stores;

public class WaypointEffects(ISpaceTradersClient client)
{
	[EffectMethod]
	public async Task Handle(WaypointLoad action, IDispatcher dispatcher)
	{
		var waypoint = (await client.GetWaypoint(action.SystemSymbol, action.WaypointSymbol)).Data;

		dispatcher.Dispatch(new WaypointUpdated(waypoint));

		if (waypoint.Traits.Any(trait => trait.Symbol == "SHIPYARD"))
		{
			dispatcher.Dispatch(new ShipyardLoad(action.SystemSymbol, action.WaypointSymbol));
		}
	}

}