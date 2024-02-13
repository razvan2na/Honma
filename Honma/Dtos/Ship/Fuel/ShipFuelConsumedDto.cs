namespace Honma.Dtos;

public readonly record struct ShipFuelConsumedDto(
    int Amount,
    DateTime Timestamp
);