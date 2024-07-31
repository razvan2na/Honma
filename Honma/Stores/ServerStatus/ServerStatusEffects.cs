using Fluxor;
using Honma.Data;
using MudBlazor;
using Refit;

namespace Honma.Stores;

public class ServerStatusEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(ServerStatusLoad action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new ServerStatusUpdated(await client.GetStatus()));
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}