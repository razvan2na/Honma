using Honma.Models;

namespace Honma.Stores;

public readonly record struct SystemsLoad(int Limit, int Page);

public readonly record struct SystemsUpdated(IReadOnlyCollection<SystemDto> Systems, int TotalSystems);

public readonly record struct SystemLoad(string Symbol);

public readonly record struct SystemUpdated(SystemDto System);

public readonly record struct SystemWaypointsLoad(string Symbol, int Page, string[]? Traits, string? Type);

public readonly record struct SystemWaypointsUpdated(IReadOnlyCollection<Waypoint> Waypoints, int TotalWaypoints);