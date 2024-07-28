using Blazored.LocalStorage;
using Fluxor;
using Honma.Actions;
using Honma.Constants;
using MudBlazor;

namespace Honma.Stores;

public class AgentHistoryEffects(ILocalStorageService localStorage, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentHistoryLoad action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory =
                await localStorage.GetItemAsync<IReadOnlyList<Models.Agent>>(LocalStorageKeys.AgentHistory) ??
                [];
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(AgentHistoryRemoveAgent action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory =
                await localStorage.GetItemAsync<IReadOnlyList<Models.Agent>>(LocalStorageKeys.AgentHistory) ??
                new List<Models.Agent>();

            agentHistory = agentHistory
                .Where(agent => agent.AccountId != action.AccountId)
                .ToList();

            await localStorage.SetItemAsync(LocalStorageKeys.AgentHistory, agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}