using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Data;
using Honma.Dtos;
using Honma.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Refit;

namespace Honma.Store;

public class AgentEffects(
    ISpaceTradersApi api,
    AuthenticationStateProvider authenticationStateProvider,
    ILocalStorageService localStorage,
    NavigationManager navigationManager,
    ISnackbar snackbar) : Effects(api, authenticationStateProvider, localStorage, navigationManager, snackbar)
{
    [EffectMethod]
    public async Task HandleAgentRegister(AgentRegister action, IDispatcher dispatcher)
    {
        try
        {
            var response = await Api.RegisterAgent(new AgentRegisterDto(action.Symbol, action.FactionSymbol.Value));

            await LocalStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, response.Data.Token);
            AuthenticationStateProvider.NotifyUserAuthentication(response.Data.Token);
            dispatcher.Dispatch(new AgentRegistered(response.Data));
            NavigationManager.NavigateTo(Routes.Home);
        }
        catch (ApiException exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task HandleAgentLogin(AgentLogin action, IDispatcher dispatcher)
    {
        await LocalStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, action.Token);

        try
        {
            var response = await Api.GetMyAgent();
            AuthenticationStateProvider.NotifyUserAuthentication(action.Token);
            dispatcher.Dispatch(new AgentLoggedIn(new Agent(response.Data, action.Token)));
            NavigationManager.NavigateTo(Routes.Home);
        }
        catch (ApiException exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
            dispatcher.Dispatch(new AgentLogout());
        }
    }

    [EffectMethod]
    public async Task HandleAgentLogout(AgentLogout action, IDispatcher dispatcher)
    {
        await LocalStorage.RemoveItemAsync(LocalStorageKeys.AuthenticationToken);
        AuthenticationStateProvider.NotifyUserLogout();
        NavigationManager.NavigateTo(Routes.Home);
    }

    [EffectMethod]
    public async Task HandleAgentInitialize(AgentInitialize action, IDispatcher dispatcher)
    {
        var token = await LocalStorage.GetItemAsync<string>(LocalStorageKeys.AuthenticationToken);

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        dispatcher.Dispatch(new AgentLogin(token));
    }
}