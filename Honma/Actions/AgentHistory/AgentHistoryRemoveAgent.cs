using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Models;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct AgentHistoryRemoveAgent(string AccountId);

public class AgentHistoryRemoveAgentHandler(ILocalStorageService localStorage, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentHistoryRemoveAgent action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               new List<Agent>();

            agentHistory = agentHistory
                .Where(agent => agent.AccountId != action.AccountId)
                .ToList();

            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}