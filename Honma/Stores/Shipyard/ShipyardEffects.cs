using Fluxor;
using Honma.Data;

namespace Honma.Stores;

public class ShipyardEffects(ISpaceTradersClient client)
{
	[EffectMethod]
	public async Task Handle(ShipyardLoad action, IDispatcher dispatcher)
	{
		var response = await client.GetShipyard(action.SystemSymbol, action.WaypointSymbol);
		var shipyard = response.Data;

		dispatcher.Dispatch(new ShipyardUpdated(shipyard));
	}
}