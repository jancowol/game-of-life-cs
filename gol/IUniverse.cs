using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		IUniverse Evolve();
		ICellLocation[] LiveCellLocations { get; }
		ICellLocation[] DeadCellLocations { get; }
	}
}