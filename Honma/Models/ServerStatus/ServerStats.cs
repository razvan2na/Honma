namespace Honma.Models;

public readonly record struct ServerStats(
    int Agents,
    int Ships,
    int Systems,
    int Waypoints
);