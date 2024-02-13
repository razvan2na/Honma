namespace Honma.Dtos;

public readonly record struct ShipEngineDto(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int Speed,
    ShipRequirementsDto Requirements
);