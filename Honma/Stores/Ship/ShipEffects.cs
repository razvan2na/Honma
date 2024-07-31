using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Stores;

public class ShipEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
	[EffectMethod]
	public async Task Handle(ShipsLoad action, IDispatcher dispatcher)
	{
		try
		{
			var (ships, meta) = await client.GetShips(action.Limit, action.Page);

			dispatcher.Dispatch(
				new ShipsUpdated(
					ships ?? throw new InvalidOperationException(),
					meta?.Total ?? throw new InvalidOperationException()
				)
			);
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}
}