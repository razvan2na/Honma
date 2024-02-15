namespace Honma.Models;

public readonly record struct ContractTerms(
    DateTime Deadline,
    ContractPayment Payment,
    IReadOnlyList<ContractDeliverGood> Deliver
);