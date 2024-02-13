namespace Honma.Dtos;

public readonly record struct JumpGateDto(
    string Symbol,
    IReadOnlyList<string> Connections
);