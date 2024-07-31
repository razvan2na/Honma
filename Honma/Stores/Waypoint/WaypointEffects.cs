using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Stores;

public class WaypointEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
	[EffectMethod]
	public async Task Handle(WaypointLoad action, IDispatcher dispatcher)
	{
		var (waypoint, _) = await client.GetWaypoint(action.SystemSymbol, action.WaypointSymbol);

		dispatcher.Dispatch(new WaypointUpdated(waypoint));

		if (waypoint.Traits.Any(trait => trait.Symbol == "MARKETPLACE"))
		{
			dispatcher.Dispatch(new WaypointMarketLoad(action.SystemSymbol, action.WaypointSymbol));
		}

		if (waypoint.Traits.Any(trait => trait.Symbol == "SHIPYARD"))
		{
			dispatcher.Dispatch(new WaypointShipyardLoad(action.SystemSymbol, action.WaypointSymbol));
		}

		if (waypoint.Type == "JUMP_GATE")
		{
			dispatcher.Dispatch(new WaypointJumpGateLoad(action.SystemSymbol, action.WaypointSymbol));
		}
	}

	[EffectMethod]
	public async Task Handle(WaypointMarketLoad action, IDispatcher dispatcher)
	{
		var (market, _) = await client.GetMarket(action.SystemSymbol, action.WaypointSymbol);

		dispatcher.Dispatch(new WaypointMarketUpdated(market));
	}

	[EffectMethod]
	public async Task Handle(WaypointShipyardLoad action, IDispatcher dispatcher)
	{
		var (shipyard, _) = await client.GetShipyard(action.SystemSymbol, action.WaypointSymbol);

		dispatcher.Dispatch(new WaypointShipyardUpdated(shipyard));
	}

	[EffectMethod]
	public async Task Handle(WaypointJumpGateLoad action, IDispatcher dispatcher)
	{
		var (jumpGate, _) = await client.GetJumpGate(action.SystemSymbol, action.WaypointSymbol);

		dispatcher.Dispatch(new WaypointJumpGateUpdated(jumpGate));
	}
}