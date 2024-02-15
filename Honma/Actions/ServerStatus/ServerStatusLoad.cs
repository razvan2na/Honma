using Fluxor;
using Honma.Data;
using MudBlazor;
using Refit;

namespace Honma.Actions;

public readonly record struct ServerStatusLoad;

public class ServerStatusLoadHandler(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task HandleServerStatusLoad(ServerStatusLoad action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new ServerStatusLoaded(await client.GetStatus()));
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}