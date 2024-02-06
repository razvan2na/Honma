namespace Honma.Dtos;

public readonly record struct LeaderboardChartsDto(
    string AgentSymbol,
    int ChartCount
);