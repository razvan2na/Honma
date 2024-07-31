using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;
using Honma.Models;
using Honma.Services;
using MudBlazor;

namespace Honma.Stores;

public class AgentHistoryEffects(AgentHistoryService agentHistoryService, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(AgentHistoryLoad action, IDispatcher dispatcher)
    {
        try
        {
            var agentHistory = await agentHistoryService.Get() ?? [];
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
            var agentHistory = await agentHistoryService.Get() ?? [];

            agentHistory = agentHistory
                .Where(agent => agent.AccountId != action.AccountId)
                .ToList();

            await agentHistoryService.Set(agentHistory);
            dispatcher.Dispatch(new AgentHistoryUpdated(agentHistory));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}