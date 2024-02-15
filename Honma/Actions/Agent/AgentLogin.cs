using Blazored.LocalStorage;
using Fluxor;
using Honma.Authentication;
using Honma.Constants;
using Honma.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct AgentLogin(string Token);

public class AgentLoginHandler(
    ISpaceTradersClient client,
    ILocalStorageService localStorage,
    AuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager,
    ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentLogin action, IDispatcher dispatcher)
    {
        await localStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, action.Token);

        try
        {
            var (agent, _) = await client.GetMyAgent();
            (authenticationStateProvider as ClientAuthenticationStateProvider)
                ?.NotifyUserAuthentication(action.Token);
            dispatcher.Dispatch(new AgentLoggedIn(agent with { Token = action.Token }));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
            dispatcher.Dispatch(new AgentLogout());
        }
    }
}