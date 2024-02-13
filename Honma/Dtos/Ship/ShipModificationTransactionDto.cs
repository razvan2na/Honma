namespace Honma.Dtos;

public readonly record struct ShipModificationTransactionDto(
    string WaypointSymbol,
    string ShipSymbol,
    string TradeSymbol,
    int TotalPrice,
    DateTime Timestamp
);