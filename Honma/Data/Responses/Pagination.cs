namespace Honma.Data.Responses;

public readonly record struct Pagination(
    int Page,
    int Limit,
    int Total
);