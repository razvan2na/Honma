namespace Honma.Models;

public readonly record struct MarketTransaction(
    string WaypointSymbol,
    string ShipSymbol,
    string TradeSymbol,
    string Type,
    int Units,
    int PricePerUnit,
    int TotalPrice,
    DateTime Timestamp
);