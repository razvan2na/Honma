using Fluxor;
using Honma.Data;
using MudBlazor;
using Refit;

namespace Honma.Actions;

public readonly record struct FactionsLoad;

public class FactionsLoadHandler(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(FactionsLoad action, IDispatcher dispatcher)
    {
        try
        {
            var (factions, _) = await client.GetFactions(20, 1);
            dispatcher.Dispatch(new FactionsLoaded(factions ?? throw new InvalidOperationException()));
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}