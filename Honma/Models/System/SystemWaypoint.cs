namespace Honma.Models;

public readonly record struct SystemWaypoint(
    string Symbol,
    string Type,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbital> Orbitals,
    string? Orbits
);