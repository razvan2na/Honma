using Honma.Models;

namespace Honma.Actions;

public readonly record struct FactionsLoad;

public readonly record struct FactionsUpdated(IReadOnlyList<Faction> Factions);