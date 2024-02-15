namespace Honma.Models;

public readonly record struct SystemDto(
    string Symbol,
    string SectorSymbol,
    string Type,
    int X,
    int Y,
    IReadOnlyList<SystemWaypoint> Waypoints,
    IReadOnlyList<SystemFaction> Factions
);