using Fluxor;

namespace Honma.Stores;

public static class UserAgentReducers
{
    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentRegistered action) => new()
    {
        Agent = action.UserData.Agent with
        {
            Token = action.UserData.Token
        }
    };

    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentLogout action) => new();

    [ReducerMethod]
    public static UserAgentState Reduce(UserAgentState state, UserAgentUpdated action) => new()
    {
        Agent = action.Agent
    };
}