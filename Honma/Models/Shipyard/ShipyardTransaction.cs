namespace Honma.Models;

public readonly record struct ShipyardTransaction(
    string WaypointSymbol,
    string ShipType,
    int Price,
    string AgentSymbol,
    DateTime Timestamp
);