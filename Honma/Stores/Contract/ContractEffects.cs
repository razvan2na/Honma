using Fluxor;
using Honma.Data;
using MudBlazor;

namespace Honma.Stores;

public class ContractEffects(ISpaceTradersClient client, ISnackbar snackbar)
{
    [EffectMethod]
    public async Task Handle(ContractsLoad action, IDispatcher dispatcher)
    {
        try
        {
            var (contracts, _) = await client.GetContracts(action.Limit, action.Page);
            dispatcher.Dispatch(new ContractsLoaded(contracts ?? throw new InvalidOperationException()));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }

    [EffectMethod]
    public async Task Handle(ContractAccept action, IDispatcher dispatcher)
    {
        try
        {
            var (response, _) = await client.AcceptContract(action.ContractId);

            dispatcher.Dispatch(new ContractUpdated(response.Contract));
            dispatcher.Dispatch(new UserAgentUpdated(response.Agent));
        }
        catch (Exception exception)
        {
            snackbar.Add(exception.Message, Severity.Error);
        }
    }
}