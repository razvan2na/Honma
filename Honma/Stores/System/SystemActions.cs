using Honma.Data;
using Honma.Models;

namespace Honma.Stores;

public readonly record struct SystemsLoad(int Limit, int Page);

public readonly record struct SystemsUpdated(List<SystemDto> Systems, Pagination Pagination);

public readonly record struct SystemLoad(string Symbol);

public readonly record struct SystemUpdated(SystemDto System);

public readonly record struct SystemWaypointsLoad(string Symbol, int Page, List<string>? Traits, string? Type);

public readonly record struct SystemWaypointsUpdated(List<Waypoint> Waypoints, Pagination Pagination);