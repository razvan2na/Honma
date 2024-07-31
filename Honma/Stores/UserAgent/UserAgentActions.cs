using Honma.Data;

namespace Honma.Stores;

public readonly record struct UserAgentInitialize;

public readonly record struct UserAgentLogin(string Token);

public readonly record struct UserAgentRegister(string Symbol, string FactionSymbol);

public readonly record struct UserAgentRegistered(AgentRegisterResponse UserData);

public readonly record struct UserAgentLogout;

public readonly record struct UserAgentUpdated(Models.Agent Agent);
