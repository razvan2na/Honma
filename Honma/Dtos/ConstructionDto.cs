namespace Honma.Dtos;

public readonly record struct ConstructionDto(
    string Symbol,
    IReadOnlyList<ConstructionMaterialDto> Materials,
    bool IsComplete
);