namespace Honma.Dtos;

public readonly record struct ServerStatsDto(
    int Agents,
    int Ships,
    int Systems,
    int Waypoints
);