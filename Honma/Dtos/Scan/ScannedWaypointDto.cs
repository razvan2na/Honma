namespace Honma.Dtos;

public readonly record struct ScannedWaypointDto(
    string Symbol,
    string Type,
    string SystemSymbol,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbitalDto> Orbitals,
    WaypointFactionDto? Faction,
    IReadOnlyList<WaypointTraitDto> Traits,
    ChartDto? Chart
);