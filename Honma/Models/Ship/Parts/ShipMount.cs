namespace Honma.Models;

public readonly record struct ShipMount(
    string Symbol,
    string Name,
    string? Description,
    int? Strength,
    IReadOnlyList<string>? Deposits,
    ShipRequirements Requirements
);