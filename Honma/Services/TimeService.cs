using Microsoft.JSInterop;

namespace Honma.Services;

public class TimeService(IJSRuntime jsRuntime)
{
    public async Task<int> GetUserTimezoneOffset()
    {
        return await jsRuntime.InvokeAsync<int>("getUserTimezoneOffset");
    }
}