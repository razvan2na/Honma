namespace Honma.Models;

public readonly record struct ScannedWaypoint(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbital> Orbitals,
    WaypointFaction? Faction,
    IReadOnlyList<WaypointTrait> Traits,
    Chart? Chart
);