using Honma.Models;

namespace Honma.Stores;

public readonly record struct FactionsLoad;

public readonly record struct FactionsUpdated(List<Faction> Factions);