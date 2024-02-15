namespace Honma.Models;

public readonly record struct Leaderboards(
    IReadOnlyList<LeaderboardCredits> MostCredits,
    IReadOnlyList<LeaderboardCharts> MostSubmittedCharts
);