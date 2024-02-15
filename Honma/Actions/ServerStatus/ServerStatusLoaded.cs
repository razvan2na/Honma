using Fluxor;
using Honma.Models;
using Honma.States;

namespace Honma.Actions;

public readonly record struct ServerStatusLoaded(ServerStatus? Status);

public class ServerStatusLoadedHandler
{
    [ReducerMethod]
    public static ServerStatusState ReduceServerStatusLoaded(ServerStatusState state, ServerStatusLoaded action) => 
        new() { Status = action.Status };
}