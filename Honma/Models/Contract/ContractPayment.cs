namespace Honma.Models;

public readonly record struct ContractPayment(
    int OnAccepted,
    int OnFulfilled
);