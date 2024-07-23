using Honma.Models;

namespace Honma.Actions;

public readonly record struct ServerStatusLoad;

public readonly record struct ServerStatusUpdated(ServerStatus? Status);