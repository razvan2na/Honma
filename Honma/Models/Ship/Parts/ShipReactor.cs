namespace Honma.Models;

public readonly record struct ShipReactor(
    string Symbol,
    string Name,
    string Description,
    double Condition,
    double Integrity,
    int PowerOutput,
    ShipRequirements Requirements
);