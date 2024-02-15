namespace Honma.Models;

public readonly record struct Meta(
    int Total,
    int Page,
    int Limit
);