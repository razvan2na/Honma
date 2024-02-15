namespace Honma.Models;

public readonly record struct Response<T>(
    T? Data,
    Meta? Meta
);