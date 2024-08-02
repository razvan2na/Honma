using System.Text;
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
			new(BreadcrumbTexts.Home, Routes.Home, false, HonmaIcons.Cube)
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
			var systemSymbol = routeData.RouteValues.First(entry => entry.Key == "systemSymbol").Value!.ToString();
			var waypointSymbol = routeData.RouteValues.First(entry => entry.Key == "waypointSymbol").Value!.ToString();

			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Systems, Routes.Systems));
			breadcrumbs.Add(new BreadcrumbItem(systemSymbol!, $"{Routes.Systems}/{systemSymbol}"));
			breadcrumbs.Add(new BreadcrumbItem(BreadcrumbTexts.Waypoints, $"{Routes.Systems}/{systemSymbol}"));
			breadcrumbs.Add(new BreadcrumbItem(waypointSymbol!, null, true));
		}

		return breadcrumbs;
	}

	public static IEnumerable<T> Replace<T, TKey>(this IEnumerable<T> source, T item, Func<T, TKey> keySelector)
		where TKey : IEquatable<TKey> =>
		source.Select(i => keySelector.Invoke(i).Equals(keySelector.Invoke(item)) ? item : i);

	public static string ToMacroCase(this string pascalCase)
	{
		if (string.IsNullOrEmpty(pascalCase))
		{
			return string.Empty;
		}

		var result = new StringBuilder();

		for (var i = 0; i < pascalCase.Length; i++)
		{
			var c = pascalCase[i];

			if (char.IsUpper(c) && i > 0)
			{
				result.Append('_');
			}

			result.Append(char.ToUpper(c));
		}

		return result.ToString();
	}

	public static string ToNaturalLanguage(this string pascalCase)
	{
		if (string.IsNullOrEmpty(pascalCase))
		{
			return pascalCase;
		}

		var result = new StringBuilder();

		foreach (var character in pascalCase)
		{
			if (char.IsUpper(character) && result.Length > 0)
			{
				result.Append(' ');
			}

			result.Append(character);
		}

		return result.ToString();
	}
}