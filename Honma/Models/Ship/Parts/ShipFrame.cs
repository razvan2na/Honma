namespace Honma.Models;

public readonly record struct ShipFrame(
    string Symbol,
    string Name,
    string Description,
    double Condition,
    double Integrity,
    int ModuleSlots,
    int MountingPoints,
    int FuelCapacity,
    ShipRequirements Requirements
);