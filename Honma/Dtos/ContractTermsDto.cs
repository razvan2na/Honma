namespace Honma.Dtos;

public readonly record struct ContractTermsDto(
    DateTime Deadline,
    ContractPaymentDto Payment,
    IReadOnlyList<ContractDeliverGoodDto> Deliver
);