namespace Honma.Models;

public readonly record struct ShipCargo(
    int Capacity,
    int Units,
    IReadOnlyList<ShipCargoItem> Inventory
);