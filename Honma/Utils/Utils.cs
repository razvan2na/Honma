using Honma.Components.AgentHistory;
using Honma.Components.Authentication;
using Honma.Components.Contracts;
using Honma.Components.Factions;
using Honma.Components.Ships;
using Honma.Components.Systems;
using Honma.Components.Waypoints;
using Honma.Constants;
using Honma.Icons;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Honma.Utils;

public static class Utils
{
	public static List<BreadcrumbItem> BuildBreadcrumbs(this RouteData routeData)
	{
		var breadcrumbs = new List<BreadcrumbItem>
		{
			new(BreadcrumbTexts.Home, Routes.Home, false, PhosphorIcons.Cube)
		};

		if (routeData.PageType == typeof(LoginPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Login, Routes.Login, true));
		}
		else if (routeData.PageType == typeof(FactionsPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Factions, Routes.Factions, true));
		}
		else if (routeData.PageType == typeof(AgentHistoryPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.AgentHistory, Routes.AgentHistory, true));
		}
		else if (routeData.PageType == typeof(ContractsPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Contracts, Routes.Contracts, true));
		}
		else if (routeData.PageType == typeof(ShipsPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Ships, Routes.Ships, true));
		}
		else if (routeData.PageType == typeof(SystemsPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems, true));
		}
		else if (routeData.PageType == typeof(SystemPage))
		{
			var systemSymbol = routeData.RouteValues.First(entry => entry.Key == "systemSymbol").Value!.ToString();

			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems));
			breadcrumbs.Add(new BreadcrumbItem(systemSymbol!, null, true));
		}
		else if (routeData.PageType == typeof(WaypointPage))
		{
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Waypoints, Routes.Waypoints, true));

			breadcrumbs.AddRange(
				routeData.RouteValues.Values
					.Where(value => value is not null)
					.Select(value => new BreadcrumbItem(value!.ToString()!, Routes.Waypoints, true))
			);
		}

		return breadcrumbs;
	}

	public static IEnumerable<T> Replace<T, TKey>(this IEnumerable<T> source, T item, Func<T, TKey> keySelector)
		where TKey : IEquatable<TKey> =>
		source.Select(i => keySelector.Invoke(i).Equals(keySelector.Invoke(item)) ? item : i);
}