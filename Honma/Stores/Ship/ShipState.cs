﻿using Fluxor;
using Honma.Models;

namespace Honma.Stores;

[FeatureState]
public record ShipState
{
	public IReadOnlyCollection<Ship> Ships { get; init; } = [];

	public int TotalShipCount { get; init; }
}