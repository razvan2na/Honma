using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Data;
using Honma.Models;
using Honma.States;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct AgentLoggedIn(Agent Agent);

public class AgentLoggedInHandler(ILocalStorageService localStorage, ISpaceTradersClient client, ISnackbar snackbar)
{
    [ReducerMethod]
    public static AgentState Reduce(AgentState state, AgentLoggedIn action) => new()
    {
        Agent = action.Agent
    };
    
    [EffectMethod]
    public async Task Handle(AgentLoggedIn action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();
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