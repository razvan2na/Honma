namespace Honma.Models;

public readonly record struct ShipReactor(
    string Symbol,
    string Name,
    string Description,
    int? Condition,
    int PowerOutput,
    ShipRequirements Requirements
);