using Fluxor;

namespace Honma.Store;

public static class ServerStatusReducers
{
    [ReducerMethod]
    public static ServerStatusState ReduceServerStatusLoaded(ServerStatusState state, ServerStatusLoaded action)
    {
        return new ServerStatusState() { Status = action.Status };
    }
}