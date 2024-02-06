using Blazored.LocalStorage;
using Fluxor;
using Honma.Data;
using Honma.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Refit;

namespace Honma.Store;

public class FactionsEffects(
    ISpaceTradersApi api,
    AuthenticationStateProvider authenticationStateProvider,
    ILocalStorageService localStorage,
    NavigationManager navigationManager,
    ISnackbar snackbar) : Effects(api, authenticationStateProvider, localStorage, navigationManager, snackbar)
{
    [EffectMethod]
    public async Task HandleFactionsLoad(FactionsLoad action, IDispatcher dispatcher)
    {
        try
        {
            dispatcher.Dispatch(
                new FactionsLoaded(
                    ((await Api.GetFactions(20, 1)).Data ?? throw new InvalidOperationException())
                    .Select(dto => new Faction(dto))
                    .ToList()
                )
            );
        }
        catch (ApiException exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }
}