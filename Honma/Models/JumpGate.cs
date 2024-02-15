namespace Honma.Models;

public readonly record struct JumpGate(
    string Symbol,
    IReadOnlyList<string> Connections
);