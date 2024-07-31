using Honma.Models;

namespace Honma.Stores;

public readonly record struct ServerStatusLoad;

public readonly record struct ServerStatusUpdated(ServerStatus Status);