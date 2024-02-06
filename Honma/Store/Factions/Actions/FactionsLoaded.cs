using Honma.Models;

namespace Honma.Store;

public readonly record struct FactionsLoaded(IReadOnlyList<Faction> Factions);