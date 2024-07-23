using Blazored.LocalStorage;
using Fluxor;
using Honma.Actions;
using Honma.Authentication;
using Honma.Constants;
using Honma.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Refit;

namespace Honma.Stores.UserAgent;

public class UserAgentEffects(
    ISpaceTradersClient client,
    ILocalStorageService localStorage,
    AuthenticationStateProvider authenticationStateProvider,
    NavigationManager navigationManager,
    ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(UserAgentInitialize action, IDispatcher dispatcher)
    {
        var token = await localStorage.GetItemAsync<string>(LocalStorageKeys.AuthenticationToken);

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        dispatcher.Dispatch(new UserAgentLogin(token));
    }

    [EffectMethod]
    public async Task Handle(UserAgentLogin action, IDispatcher dispatcher)
    {
        await localStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, action.Token);

        try
        {
            var (agent, _) = await client.GetMyAgent();
            (authenticationStateProvider as ClientAuthenticationStateProvider)
                ?.NotifyUserAuthentication(action.Token);
            dispatcher.Dispatch(new UserAgentUpdated(agent with { Token = action.Token }));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
            dispatcher.Dispatch(new UserAgentLogout());
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentLogout action, IDispatcher dispatcher)
    {
        await localStorage.RemoveItemAsync(LocalStorageKeys.AuthenticationToken);
        (authenticationStateProvider as ClientAuthenticationStateProvider)?.NotifyUserLogout();
        navigationManager.NavigateTo(Routes.Home);
    }

    [EffectMethod]
    public async Task Handle(UserAgentRegister action, IDispatcher dispatcher)
    {
        try
        {
            var (userData, _) =
                await client.RegisterAgent(new AgentRegisterRequest(action.Symbol, action.FactionSymbol));

            await localStorage.SetItemAsync(LocalStorageKeys.AuthenticationToken, userData.Token);
            (authenticationStateProvider as ClientAuthenticationStateProvider)
                ?.NotifyUserAuthentication(userData.Token);
            dispatcher.Dispatch(new UserAgentRegistered(userData));
            navigationManager.NavigateTo(Routes.Home);
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentRegistered action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory =
                await localStorage.GetItemAsync<IReadOnlyList<Models.Agent>>(LocalStorageKeys.AgentHistory) ??
                new List<Models.Agent>();
            var serverStatus = await client.GetStatus();
            var newAgent = action.UserData.Agent with
            {
                Token = action.UserData.Token,
                ExpiresOn = serverStatus.ServerResets.Next
            };

            if (agentHistory.Any(agent => agent.AccountId == action.UserData.Agent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == action.UserData.Agent.AccountId ? newAgent : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Models.Agent>(agentHistory) { newAgent };
            }

            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(UserAgentUpdated action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory =
                await localStorage.GetItemAsync<IReadOnlyList<Models.Agent>>(LocalStorageKeys.AgentHistory) ??
                new List<Models.Agent>();
            var serverStatus = await client.GetStatus();
            var newAgent = action.Agent with
            {
                ExpiresOn = serverStatus.ServerResets.Next
            };

            if (agentHistory.Any(agent => agent.AccountId == action.Agent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == action.Agent.AccountId ? newAgent : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Models.Agent>(agentHistory) { newAgent };
            }

            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}