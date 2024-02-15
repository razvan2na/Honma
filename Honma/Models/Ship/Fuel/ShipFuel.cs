namespace Honma.Models;

public readonly record struct ShipFuel(
    int Current,
    int Capacity,
    ShipFuelConsumed? Consumed
);