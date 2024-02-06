using Blazored.LocalStorage;
using Honma.Authentication;
using Honma.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Honma.Store;

public abstract class Effects(
    ISpaceTradersApi api,
    AuthenticationStateProvider authenticationStateProvider,
    ILocalStorageService localStorage,
    NavigationManager navigationManager,
    ISnackbar snackbar)
{
    protected readonly ISpaceTradersApi Api = api;

    protected readonly ClientAuthenticationStateProvider AuthenticationStateProvider =
        authenticationStateProvider as ClientAuthenticationStateProvider ?? throw new InvalidOperationException();

    protected readonly ILocalStorageService LocalStorage = localStorage;
    protected readonly NavigationManager NavigationManager = navigationManager;
    protected readonly ISnackbar Snackbar = snackbar;
}