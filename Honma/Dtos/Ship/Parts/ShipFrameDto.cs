namespace Honma.Dtos;

public readonly record struct ShipFrameDto(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int ModuleSlots,
    int MountingPoints,
    int FuelCapacity,
    ShipRequirementsDto Requirements
);