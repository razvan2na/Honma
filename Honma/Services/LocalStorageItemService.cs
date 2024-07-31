using Blazored.LocalStorage;

namespace Honma.Services;

public abstract class LocalStorageItemService<T>(ILocalStorageService localStorage)
{
	protected abstract string Key { get; }

	public async Task<T?> Get() => await localStorage.GetItemAsync<T>(Key);

	public async Task Set(T value) => await localStorage.SetItemAsync(Key, value);

	public async Task Remove() => await localStorage.RemoveItemAsync(Key);
}