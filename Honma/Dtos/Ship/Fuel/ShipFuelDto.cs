namespace Honma.Dtos;

public readonly record struct ShipFuelDto(
    int Current,
    int Capacity,
    ShipFuelConsumedDto? Consumed
);