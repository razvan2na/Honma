namespace Honma.Dtos;

public readonly record struct ShipReactorDto(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int PowerOutput,
    ShipRequirementsDto Requirements
);