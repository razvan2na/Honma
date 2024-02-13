namespace Honma.Dtos;

public readonly record struct ContractPaymentDto(
    int OnAccepted,
    int OnFulfilled
);