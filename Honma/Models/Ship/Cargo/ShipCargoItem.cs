namespace Honma.Models;

public readonly record struct ShipCargoItem(
    string Symbol,
    string Name,
    string Description,
    int Units
);