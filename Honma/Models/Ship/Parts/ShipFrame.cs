namespace Honma.Models;

public readonly record struct ShipFrame(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int ModuleSlots,
    int MountingPoints,
    int FuelCapacity,
    ShipRequirements Requirements
);