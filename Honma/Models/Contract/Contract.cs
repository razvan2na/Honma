namespace Honma.Models;

public readonly record struct Contract(
    string Id,
    string FactionSymbol,
    string Type,
    ContractTerms Terms,
    bool Accepted,
    bool Fulfilled,
    DateTime DeadlineToAccept
);