namespace Honma.Models;

public readonly record struct Faction(
    string Symbol,
    string Name,
    string Description,
    string Headquarters,
    IReadOnlyList<FactionTrait> Traits,
    bool IsRecruiting
);