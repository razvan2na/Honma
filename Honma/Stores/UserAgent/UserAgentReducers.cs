using Fluxor;
using Honma.Actions;

namespace Honma.Stores.UserAgent;

public static class UserAgentReducers
{
    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentRegistered action)
    {
        return new UserAgentState
        {
            Agent = action.UserData.Agent with
            {
                Token = action.UserData.Token
            }
        };
    }

    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentLogout action)
    {
        return new UserAgentState();
    }

    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentUpdated action)
    {
        return new UserAgentState
        {
            Agent = action.Agent
        };
    }
}