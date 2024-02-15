using Blazored.LocalStorage;
using Fluxor;
using Honma.Authentication;
using Honma.Constants;
using Honma.States;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Honma.Actions;

public readonly record struct AgentLogout;

public class AgentLogoutHandler(
    ILocalStorageService localStorage,
    AuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager)
{
    [ReducerMethod]
    public static AgentState Reduce(AgentState state, AgentLogout action) => new();

    [EffectMethod]
    public async Task Handle(AgentLogout action, IDispatcher dispatcher)
    {
        await localStorage.RemoveItemAsync(LocalStorageKeys.AuthenticationToken);
        (authenticationStateProvider as ClientAuthenticationStateProvider)?.NotifyUserLogout();
        navigationManager.NavigateTo(Routes.Home);
    }
}