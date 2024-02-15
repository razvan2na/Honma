using Blazored.LocalStorage;
using Fluxor;
using Honma.Authentication;
using Honma.Constants;
using Honma.Data;
using Honma.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Refit;

namespace Honma.Actions;

public readonly record struct AgentRegister(string Symbol, string FactionSymbol);

public class AgentRegisterHandler(
    ISpaceTradersClient client,
    ILocalStorageService localStorage,
    AuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager,
    ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentRegister action, IDispatcher dispatcher)
    {
        try
        {
            var (userData, _) =
                await client.RegisterAgent(new AgentRegisterRequest(action.Symbol, action.FactionSymbol));
            
            await localStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, userData.Token);
            (authenticationStateProvider as ClientAuthenticationStateProvider)
                ?.NotifyUserAuthentication(userData.Token);
            dispatcher.Dispatch(new AgentRegistered(userData));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}