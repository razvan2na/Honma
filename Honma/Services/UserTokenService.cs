using Blazored.LocalStorage;
using Honma.Constants;

namespace Honma.Services;

public class UserTokenService(ILocalStorageService localStorage) : LocalStorageItemService<string>(localStorage)
{
	protected override string Key => LocalStorageKeys.AuthenticationToken;
}