using Blazored.LocalStorage;
using Fluxor;
using Honma.Constants;

namespace Honma.Actions;

public readonly record struct AgentInitialize;

public class AgentInitializeHandler(ILocalStorageService localStorage)
{
    [EffectMethod]
    public async Task Handle(AgentInitialize action, IDispatcher dispatcher)
    {
        var token = await localStorage.GetItemAsync<string>(LocalStorageKeys.AuthenticationToken);

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        dispatcher.Dispatch(new AgentLogin(token));
    }
}