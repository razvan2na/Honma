namespace Honma.Dtos;

public readonly record struct MarketTransactionDto(
    string WaypointSymbol,
    string ShipSymbol,
    string TradeSymbol,
    string Type,
    int Units,
    int PricePerUnit,
    int TotalPrice,
    DateTime Timestamp
);