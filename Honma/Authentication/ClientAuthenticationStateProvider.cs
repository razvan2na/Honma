using System.Security.Claims;
using Blazored.LocalStorage;
using Honma.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace Honma.Authentication;

public class ClientAuthenticationStateProvider(ILocalStorageService localStorage) : AuthenticationStateProvider
{
    private const string AuthenticationType = "tokenAuth";

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await localStorage.GetItemAsync<string>(LocalStorageKeys.AuthenticationToken);
        return string.IsNullOrWhiteSpace(token) ? UnauthenticatedState : AuthenticatedState(token);
    }

    public void NotifyUserAuthentication(string token)
    {
        NotifyAuthenticationStateChanged(Task.FromResult(AuthenticatedState(token)));
    }

    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(UnauthenticatedState));
    }

    private static AuthenticationState UnauthenticatedState => new(new ClaimsPrincipal(new ClaimsIdentity()));

    private static AuthenticationState AuthenticatedState(string token)
    {
        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, token) }, AuthenticationType)));
    }
}