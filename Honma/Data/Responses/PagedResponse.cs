namespace Honma.Data;

public readonly record struct PagedResponse<T>(
    T Data,
    Pagination Meta
);