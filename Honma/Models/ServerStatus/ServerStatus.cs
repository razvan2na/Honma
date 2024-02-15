namespace Honma.Models;

public readonly record struct ServerStatus(
    string Status,
    string Version,
    DateTime ResetDate,
    string Description,
    ServerStats Stats,
    Leaderboards Leaderboards,
    ServerReset ServerResets,
    IReadOnlyList<Announcement> Announcements,
    IReadOnlyList<Link> Links
);