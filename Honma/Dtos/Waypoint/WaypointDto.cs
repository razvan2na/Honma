namespace Honma.Dtos;

public readonly record struct WaypointDto(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbitalDto> Orbitals,
    string? Orbits,
    WaypointFactionDto? Faction,
    IReadOnlyList<WaypointTraitDto> Traits,
    IReadOnlyList<WaypointModifierDto> Modifiers,
    ChartDto? Chart,
    bool IsUnderConstruction
);