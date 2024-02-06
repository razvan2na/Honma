using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Honma.Constants;

namespace Honma.Authentication;

public class AuthenticationHeaderHandler(ILocalStorageService localStorage) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await localStorage.GetItemAsync<string>(LocalStorageKeys.AuthenticationToken, cancellationToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}