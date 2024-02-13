namespace Honma.Dtos;

public readonly record struct SystemDto(
    string Symbol,
    string SectorSymbol,
    string Type,
    int X,
    int Y,
    IReadOnlyList<SystemWaypointDto> Waypoints,
    IReadOnlyList<SystemFactionDto> Factions
);