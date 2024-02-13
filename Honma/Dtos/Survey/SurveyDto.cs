namespace Honma.Dtos;

public readonly record struct SurveyDto(
    string Signature,
    string Symbol,
    IReadOnlyList<SurveyDepositDto> Deposits,
    DateTime Expiration,
    string Size
);