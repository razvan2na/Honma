using Fluxor;
using Honma.Data;
using Honma.Utils;
using MudBlazor;

namespace Honma.Stores;

public class ShipEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
	[EffectMethod]
	public async Task Handle(ShipsLoad action, IDispatcher dispatcher)
	{
		try
		{
			var (ships, pagination) = await client.GetShips(action.Limit, action.Page);

			dispatcher.Dispatch(
				new ShipsUpdated(
					ships ?? throw new InvalidOperationException(),
					pagination
				)
			);
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}

	[EffectMethod]
	public async Task Handle(ShipPurchase action, IDispatcher dispatcher)
	{
		try
		{
			var response = (await client.PurchaseShip(new ShipPurchaseRequest(action.ShipType, action.WaypointSymbol))).Data;

			dispatcher.Dispatch(new UserAgentUpdated(response.Agent));

			snackbar.Add("Ship purchased!", Severity.Success);
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}
}