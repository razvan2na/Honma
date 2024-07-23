using Fluxor;
using Honma.Actions;

namespace Honma.Stores.ServerStatus;

public static class ServerStatusReducers
{
    [ReducerMethod]
    public static ServerStatusState Reduce(ServerStatusState state, ServerStatusUpdated action)
    {
        return new ServerStatusState { Status = action.Status };
    }
}