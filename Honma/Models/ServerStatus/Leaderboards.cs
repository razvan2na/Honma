namespace Honma.Models;

public readonly record struct Leaderboards(
    List<LeaderboardCredits> MostCredits,
    List<LeaderboardCharts> MostSubmittedCharts
);