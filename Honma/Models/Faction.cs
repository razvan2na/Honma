using Honma.Dtos;

namespace Honma.Models;

public readonly record struct Faction(
    FactionSymbol Symbol,
    string Name,
    string Description,
    string Headquarters,
    IReadOnlyList<FactionTrait> Traits,
    bool IsRecruiting
)
{
    public Faction(FactionDto dto) : this(
        new FactionSymbol(dto.Symbol),
        dto.Name,
        dto.Description,
        dto.Headquarters,
        dto.Traits.Select(trait => new FactionTrait(trait)).ToList(),
        dto.IsRecruiting)
    {
    }
}