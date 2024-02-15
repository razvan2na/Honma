using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Actions;

public readonly record struct ContractsLoadAction(int Limit, int Page);

public class ContractsLoadHandler(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(ContractsLoadAction action, IDispatcher dispatcher)
    {
        try
        {
            var (contracts, meta) = await client.GetContracts(action.Limit, action.Page);
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}