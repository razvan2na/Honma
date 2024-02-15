namespace Honma.Models;

public readonly record struct Construction(
    string Symbol,
    IReadOnlyList<ConstructionMaterial> Materials,
    bool IsComplete
);