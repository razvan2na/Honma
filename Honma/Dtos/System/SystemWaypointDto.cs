namespace Honma.Dtos;

public readonly record struct SystemWaypointDto(
    string Symbol,
    string Type,
    int X,
    int Y,
    IReadOnlyList<WaypointOrbitalDto> Orbitals,
    string? Orbits
);