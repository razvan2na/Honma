namespace Honma.Models;

public readonly record struct Chart(
    string? WaypointSymbol,
    string? SubmittedBy,
    DateTime SubmittedOn
);