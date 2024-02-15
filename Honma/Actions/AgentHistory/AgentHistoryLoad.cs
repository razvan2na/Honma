using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Models;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct AgentHistoryLoad;

public class AgentHistoryHandler(ILocalStorageService localStorage, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentHistoryLoad action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await localStorage.GetItemAsync<IReadOnlyList<Agent>>(LocalStorageKeys.AgentHistory) ??
                               [];
            dispatcher.Dispatch(new AgentHistoryLoaded(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}