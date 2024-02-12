using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Data;
using Honma.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Honma.Store;

public class AgentHistoryEffects(
    ISpaceTradersApi api,
    AuthenticationStateProvider authenticationStateProvider,
    ILocalStorageService localStorage,
    NavigationManager navigationManager,
    ISnackbar snackbar) : Effects(api, authenticationStateProvider, localStorage, navigationManager, snackbar)
{
    [EffectMethod]
    public async Task HandleAgentHistoryLoad(AgentHistoryLoad action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               [];
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task HandleAgentRegistered(AgentRegistered action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();
            var serverStatus = await api.GetStatus();

            if (agentHistory.Any(agent => agent.AccountId == action.UserData.Agent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == action.UserData.Agent.AccountId
                        ? new Agent(action.UserData.Agent, action.UserData.Token, serverStatus.ServerResets.Next)
                        : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Agent>(agentHistory)
                {
                    new(
                        action.UserData.Agent,
                        action.UserData.Token,
                        serverStatus.ServerResets.Next
                    )
                };
            }


            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task HandleAgentLoggedIn(AgentLoggedIn action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await LocalStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();
            var serverStatus = await api.GetStatus();

            if (agentHistory.Any(agent => agent.AccountId == action.Agent.AccountId))
            {
                agentHistory = agentHistory
                    .Select(agent => agent.AccountId == action.Agent.AccountId
                        ? action.Agent with { ExpiresOn = serverStatus.ServerResets.Next }
                        : agent)
                    .ToList();
            }
            else
            {
                agentHistory = new List<Agent>(agentHistory)
                {
                    action.Agent with
                    {
                        ExpiresOn = serverStatus.ServerResets.Next
                    }
                };
            }

            await LocalStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task HandleAgentHistoryRemoveAgent(AgentHistoryRemoveAgent action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await LocalStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();

            agentHistory = agentHistory
                .Where(agent => agent.AccountId != action.AccountId)
                .ToList();

            await LocalStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            Snackbar.Add(exception.Message, Severity.Error);
        }
    }
}