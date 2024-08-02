namespace Honma.Data;

public readonly record struct Pagination(
    int Total,
    int Page,
    int Limit
);