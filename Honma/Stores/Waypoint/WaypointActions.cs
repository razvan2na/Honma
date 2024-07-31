using Honma.Models;

namespace Honma.Stores;

public readonly record struct WaypointLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct WaypointUpdated(Waypoint Waypoint);

public readonly record struct WaypointMarketLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct WaypointMarketUpdated(Market Market);

public readonly record struct WaypointShipyardLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct WaypointShipyardUpdated(Shipyard Shipyard);

public readonly record struct WaypointJumpGateLoad(string SystemSymbol, string WaypointSymbol);

public readonly record struct WaypointJumpGateUpdated(JumpGate JumpGate);