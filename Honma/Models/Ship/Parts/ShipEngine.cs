namespace Honma.Models;

public readonly record struct ShipEngine(
    string Symbol,
    string Name,
    string Description,
    double Condition,
    double Integrity,
    int Speed,
    ShipRequirements Requirements
);