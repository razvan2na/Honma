using Fluxor;
using Honma.Actions;

namespace Honma.Stores;

public static class AgentHistoryReducers
{
    [ReducerMethod]
    public static AgentHistoryState Reduce(AgentHistoryState state, AgentHistoryUpdated action)
    {
        return new AgentHistoryState { Agents = action.Agents };
    }
}