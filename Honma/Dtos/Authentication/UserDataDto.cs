using Honma.Models;

namespace Honma.Dtos;

public readonly record struct UserDataDto(
    AgentDto Agent,
    string Token
);