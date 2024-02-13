namespace Honma.Dtos;

public readonly record struct ShipRequirementsDto(
    int? Power,
    int? Crew,
    int? Slots
);