namespace Honma.Models;

public readonly record struct Survey(
    string Signature,
    string Symbol,
    List<SurveyDeposit> Deposits,
    DateTime Expiration,
    string Size
);