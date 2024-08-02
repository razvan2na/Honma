using Honma.Models;

namespace Honma.Stores;

public readonly record struct WaypointLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct WaypointUpdated(Waypoint Waypoint);
