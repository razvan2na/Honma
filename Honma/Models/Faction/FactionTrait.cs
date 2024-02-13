using Honma.Dtos;

namespace Honma.Models;

public readonly record struct FactionTrait(
    FactionTraitSymbol Symbol,
    string Name,
    string Description
)
{
    public FactionTrait(FactionTraitDto dto) : this(new FactionTraitSymbol(dto.Symbol), dto.Name, dto.Description)
    {
    }
}