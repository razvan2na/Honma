namespace Honma.Dtos;

public readonly record struct ContractDto(
    string Id,
    string FactionSymbol,
    string Type,
    ContractTermsDto Terms,
    bool Accepted,
    bool Fulfilled,
    DateTime DeadlineToAccept
);