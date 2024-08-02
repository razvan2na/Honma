using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Stores;

public class SystemEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
	[EffectMethod]
	public async Task Handle(SystemsLoad action, IDispatcher dispatcher)
	{
		try
		{
			var (systems, meta) = await client.GetSystems(action.Limit, action.Page);

			dispatcher.Dispatch(
				new SystemsUpdated(
					systems ?? throw new InvalidOperationException(),
					meta.Total
				)
			);
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}

	[EffectMethod]
	public async Task Handle(SystemLoad action, IDispatcher dispatcher)
	{
		try
		{
			var system = (await client.GetSystem(action.Symbol)).Data;

			dispatcher.Dispatch(new SystemUpdated(system));
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}

	[EffectMethod]
	public async Task Handle(SystemWaypointsLoad action, IDispatcher dispatcher)
	{
		try
		{
			var (waypoints, meta) = await client.GetSystemWaypoints(
				action.Symbol, 10, action.Page, action.Traits, action.Type
			);

			dispatcher.Dispatch(new SystemWaypointsUpdated(
				waypoints ?? throw new InvalidOperationException(),
				meta.Total
			));
		}
		catch (Exception exception)
		{
			snackbar.Add(exception.Message, Severity.Error);
		}
	}
}