using Fluxor;
using Honma.Actions;

namespace Honma.Stores.Contract;

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
            .Select(contract => contract.Id == action.Contract.Id ? action.Contract : contract)
            .ToList()
    };
}