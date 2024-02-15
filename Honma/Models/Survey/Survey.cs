namespace Honma.Models;

public readonly record struct Survey(
    string Signature,
    string Symbol,
    IReadOnlyList<SurveyDeposit> Deposits,
    DateTime Expiration,
    string Size
);