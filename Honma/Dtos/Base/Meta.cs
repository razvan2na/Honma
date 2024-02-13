namespace Honma.Dtos;

public readonly record struct Meta(
    int Total,
    int Page,
    int Limit
);