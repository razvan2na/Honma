namespace Honma.Models;

public readonly record struct ShipRequirements(
    int? Power,
    int? Crew,
    int? Slots
);