namespace Honma.Data;

public readonly record struct PagedResponse<T>(
    List<T> Data,
    Pagination Meta
);