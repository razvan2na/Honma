using Fluxor;

namespace Honma.Stores;

public static class ServerStatusReducers
{
    [ReducerMethod]
    public static ServerStatusState Reduce(ServerStatusState state, ServerStatusUpdated action) => new()
    {
        Status = action.Status
    };
}