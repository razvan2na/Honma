using Blazored.LocalStorage;
using Fluxor;
using Honma.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Refit;

namespace Honma.Store;

public class ServerStatusEffects(
    ISpaceTradersApi api,
    AuthenticationStateProvider authenticationStateProvider,
    ILocalStorageService localStorage,
    NavigationManager navigationManager,
    ISnackbar snackbar) : Effects(api, authenticationStateProvider, localStorage, navigationManager, snackbar)
{
    [EffectMethod]
    public async Task HandleServerStatusLoad(ServerStatusLoad action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(new ServerStatusLoaded(await Api.GetStatus()));
        }
        catch (ApiException exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }
}