using Honma.Icons;
using OneOf;

namespace Honma.Models;

[GenerateOneOf]
public partial class ShipPart : OneOfBase<ShipFrame, ShipReactor, ShipEngine, ShipModule, ShipMount>
{
	public bool IsFrame => IsT0;
	public bool IsReactor => IsT1;
	public bool IsEngine => IsT2;
	public bool IsModule => IsT3;
	public bool IsMount => IsT4;

	public ShipFrame Frame => AsT0;
	public ShipReactor Reactor => AsT1;
	public ShipEngine Engine => AsT2;
	public ShipModule Module => AsT3;
	public ShipMount Mount => AsT4;

	public bool TryGetFrame(out ShipFrame? frame)
	{
		frame = IsFrame ? Frame : null;
		return IsFrame;
	}

	public bool TryGetReactor(out ShipReactor? reactor)
	{
		reactor = IsReactor ? Reactor : null;
		return IsReactor;
	}

	public bool TryGetEngine(out ShipEngine? engine)
	{
		engine = IsEngine ? Engine : null;
		return IsEngine;
	}

	public bool TryGetModule(out ShipModule? module)
	{
		module = IsModule ? Module : null;
		return IsModule;
	}

	public bool TryGetMount(out ShipMount? mount)
	{
		mount = IsMount ? Mount : null;
		return IsMount;
	}

	public string TypeName => Match(
		_ => "Frame",
		_ => "Reactor",
		_ => "Engine",
		_ => "Module",
		_ => "Mount"
	);

	public string Icon => Match(
		_ => HonmaIcons.Frame,
		_ => HonmaIcons.Reactor,
		_ => HonmaIcons.Engine,
		_ => HonmaIcons.Module,
		_ => HonmaIcons.Mount
	);

	public string Name => Match(
		frame => frame.Name,
		reactor => reactor.Name,
		engine => engine.Name,
		module => module.Name,
		mount => mount.Name
	);

	public string Description => Match(
		frame => frame.Description,
		reactor => reactor.Description,
		engine => engine.Description,
		module => module.Description,
		mount => mount.Description ?? string.Empty
	);

	public ShipRequirements Requirements => Match(
		frame => frame.Requirements,
		reactor => reactor.Requirements,
		engine => engine.Requirements,
		module => module.Requirements,
		mount => mount.Requirements
	);

	public double? Condition => Match<double?>(
		frame => frame.Condition,
		reactor => reactor.Condition,
		engine => engine.Condition,
		_ => null,
		_ => null
	);

	public double? Integrity => Match<double?>(
		frame => frame.Integrity,
		reactor => reactor.Integrity,
		engine => engine.Integrity,
		_ => null,
		_ => null
	);
}