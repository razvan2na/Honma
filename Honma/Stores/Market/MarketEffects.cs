using System.Net;
using Fluxor;
using Honma.Clients;
using MudBlazor;

namespace Honma.Stores;

public class MarketEffects(ISystemsClient systemsClient, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(MarketLoad action, IDispatcher dispatcher)
    {
        try
        {
            var response = await systemsClient.GetMarket(action.SystemSymbol, action.WaypointSymbol);

            dispatcher.Dispatch(new MarketUpdated(response.Data));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}