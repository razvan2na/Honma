namespace Honma.Models;

public readonly record struct Waypoint(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbital> Orbitals,
    string? Orbits,
    WaypointFaction? Faction,
    IReadOnlyList<WaypointTrait> Traits,
    IReadOnlyList<WaypointModifier> Modifiers,
    Chart? Chart,
    bool IsUnderConstruction
);