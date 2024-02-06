namespace Honma.Dtos;

public readonly record struct LeaderboardsDto(
    IReadOnlyList<LeaderboardCreditsDto> MostCredits,
    IReadOnlyList<LeaderboardChartsDto> MostSubmittedCharts
);