namespace Honma.Models;

public readonly record struct ShipModificationTransaction(
    string WaypointSymbol,
    string ShipSymbol,
    string TradeSymbol,
    int TotalPrice,
    DateTime Timestamp
);