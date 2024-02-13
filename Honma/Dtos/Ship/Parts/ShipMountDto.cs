namespace Honma.Dtos;

public readonly record struct ShipMountDto(
    string Symbol,
    string Name,
    string? Description,
    int? Strength,
    IReadOnlyList<string>? Deposits,
    ShipRequirementsDto Requirements
);