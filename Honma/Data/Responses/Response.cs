namespace Honma.Data.Responses;

public readonly record struct Response<T>(
    T? Data,
    Pagination? Meta
);