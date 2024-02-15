using Fluxor;
using Honma.Models;
using Honma.States;

namespace Honma.Actions;

public readonly record struct AgentHistoryLoaded(IReadOnlyList<Agent> Agents);

public class AgentHistoryLoadedHandler
{
    [ReducerMethod]
    public static AgentHistoryState ReduceAgentHistoryLoaded(AgentHistoryState state, AgentHistoryLoaded action) => 
        new() { Agents = action.Agents };
}