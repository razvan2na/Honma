namespace Honma.Data;

public readonly record struct Meta(
    int Total,
    int Page,
    int Limit
);