using Fluxor;
using Honma.Models;

namespace Honma.Store;

public static class AgentReducers
{
    [ReducerMethod]
    public static AgentState ReduceAgentRegistered(AgentState state, AgentRegistered action)
    {
        return new AgentState() { Agent = new Agent(action.UserData.Agent, action.UserData.Token) };
    }

    [ReducerMethod]
    public static AgentState ReduceAgentLoggedIn(AgentState state, AgentLoggedIn action)
    {
        return new AgentState() { Agent = action.Agent };
    }

    [ReducerMethod]
    public static AgentState ReduceAgentLogout(AgentState state, AgentLogout action)
    {
        return new AgentState();
    }
}