namespace Honma.Dtos;

public readonly record struct LeaderboardCreditsDto(
    string AgentSymbol,
    long Credits
);