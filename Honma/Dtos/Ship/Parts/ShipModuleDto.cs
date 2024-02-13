namespace Honma.Dtos;

public readonly record struct ShipModuleDto(
    string Symbol,
    int? Capacity,
    int? Range,
    string Name,
    string Description,
    ShipRequirementsDto Requirements
);