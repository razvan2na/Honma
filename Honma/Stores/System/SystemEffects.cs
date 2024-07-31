using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Stores;

public class SystemEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
	[EffectMethod]
	public async Task Handle(SystemLoad action, IDispatcher dispatcher)
	{
		try
		{
			var (system, _) = await client.GetSystem(action.SystemSymbol);
			dispatcher.Dispatch(new SystemUpdated(system));
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}
}