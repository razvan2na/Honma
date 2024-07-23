using Fluxor;
using Honma.Actions;
using Honma.Data;
using MudBlazor;
using Refit;

namespace Honma.Stores.Faction;

public class FactionEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(FactionsLoad action, IDispatcher dispatcher)
    {
        try
        {
            var (factions, _) = await client.GetFactions(20, 1);
            dispatcher.Dispatch(new FactionsUpdated(factions ?? throw new InvalidOperationException()));
        }
        catch (ApiException exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}