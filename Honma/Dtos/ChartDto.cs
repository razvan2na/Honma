namespace Honma.Dtos;

public readonly record struct ChartDto(
    string? WaypointSymbol,
    string? SubmittedBy,
    DateTime SubmittedOn
);