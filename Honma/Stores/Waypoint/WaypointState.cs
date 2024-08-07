﻿using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record WaypointState
{
	public Waypoint? Waypoint { get; init; }
}