namespace Honma.Dtos;

public readonly record struct FactionDto(
    string Symbol,
    string Name,
    string Description,
    string Headquarters,
    IReadOnlyList<FactionTraitDto> Traits,
    bool IsRecruiting
);