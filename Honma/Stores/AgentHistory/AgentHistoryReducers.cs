using Fluxor;

namespace Honma.Stores;

public static class AgentHistoryReducers
{
    [ReducerMethod]
    public static AgentHistoryState Reduce(AgentHistoryState state, AgentHistoryUpdated action) =>
        new() { Agents = action.Agents };
}