namespace Honma.Dtos;

public readonly record struct ServerStatusDto(
    string Status,
    string Version,
    DateTime ResetDate,
    string Description,
    ServerStatsDto Stats,
    LeaderboardsDto Leaderboards,
    ServerResetDto ServerResets,
    IReadOnlyList<AnnouncementDto> Announcements,
    IReadOnlyList<LinkDto> Links
);