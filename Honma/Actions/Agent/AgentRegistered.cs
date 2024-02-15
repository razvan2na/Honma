using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Data;
using Honma.Models;
using Honma.States;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct AgentRegistered(AgentRegisterResponse UserData);

public class AgentRegisteredHandler(ILocalStorageService localStorage, ISnackbar snackbar, ISpaceTradersClient client)
{
    [ReducerMethod]
    public static AgentState Reduce(AgentState state, AgentRegistered action) => new()
    {
        Agent = action.UserData.Agent with
        {
            Token = action.UserData.Token
        }
    };
    
    [EffectMethod]
    public async Task Handle(AgentRegistered action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();
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
                agentHistory = new List<Agent>(agentHistory) { newAgent };
            }

            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}