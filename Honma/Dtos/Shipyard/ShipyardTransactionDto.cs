namespace Honma.Dtos;

public readonly record struct ShipyardTransactionDto(
    string WaypointSymbol,
    string ShipType,
    int Price,
    string AgentSymbol,
    DateTime Timestamp
);