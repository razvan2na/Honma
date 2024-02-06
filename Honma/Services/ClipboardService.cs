using Microsoft.JSInterop;

namespace Honma.Services;

public class ClipboardService(IJSRuntime jsRuntime)
{
    public async Task CopyToClipboard(string text)
    {
        await jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}