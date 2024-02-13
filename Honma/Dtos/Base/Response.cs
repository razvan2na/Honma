namespace Honma.Dtos;

public readonly record struct Response<T>(
    T? Data,
    Meta? Meta
);