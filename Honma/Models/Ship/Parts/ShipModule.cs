namespace Honma.Models;

public readonly record struct ShipModule(
    string Symbol,
    int? Capacity,
    int? Range,
    string Name,
    string Description,
    ShipRequirements Requirements
);