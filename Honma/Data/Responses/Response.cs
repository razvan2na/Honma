namespace Honma.Data;

public readonly record struct Response<T>(
	T Data
);