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
}