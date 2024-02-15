namespace Honma.Models;

public readonly record struct ShipEngine(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int Speed,
    ShipRequirements Requirements
);