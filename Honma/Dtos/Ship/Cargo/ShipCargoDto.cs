namespace Honma.Dtos;

public readonly record struct ShipCargoDto(
    int Capacity,
    int Units,
    IReadOnlyList<ShipCargoItemDto> Inventory
);