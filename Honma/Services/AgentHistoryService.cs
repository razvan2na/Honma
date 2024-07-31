using Blazored.LocalStorage;
using Honma.Constants;
using Honma.Models;

namespace Honma.Services;

public class AgentHistoryService(ILocalStorageService localStorage)
	: LocalStorageItemService<IReadOnlyCollection<Agent>>(localStorage)
{
	protected override string Key => LocalStorageKeys.AgentHistory;
}