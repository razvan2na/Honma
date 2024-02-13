namespace Honma.Dtos;

public readonly record struct ShipCargoItemDto(
    string Symbol,
    string Name,
    string Description,
    int Units
);