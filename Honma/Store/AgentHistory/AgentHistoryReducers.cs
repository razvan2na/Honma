using Fluxor;

namespace Honma.Store;

public static class AgentHistoryReducers
{
    [ReducerMethod]
    public static AgentHistoryState ReduceAgentHistoryLoaded(AgentHistoryState state, AgentHistoryLoaded action)
    {
        return new AgentHistoryState() { Agents = action.Agents };
    }
}