namespace Honma.Dtos;

public readonly record struct ServerStatusDto(
    string Status,
    string Version,
    string ResetDate,
    string Description,
    ServerStatsDto Stats,
    LeaderboardsDto Leaderboards,
    ServerResetDto ServerResets,
    IReadOnlyList<AnnouncementDto> Announcements,
    IReadOnlyList<LinkDto> Links
);