using Fluxor;
using Honma.Actions;
using Honma.Stores.Contract;
using Honma.Utils;

namespace Honma.Stores;

public static class ContractReducers
{
    [ReducerMethod]
    public static ContractState Reduce(ContractState state, ContractsLoaded action)
    {
        return new ContractState
        {
            Contracts = action.Contracts
        };
    }

    [ReducerMethod]
    public static ContractState Reduce(ContractState state, ContractUpdated action) => new()
    {
        Contracts = state.Contracts?
            .Replace(action.Contract, contract => contract.Id)
            .ToList()
    };
}