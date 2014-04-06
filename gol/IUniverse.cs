using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		ICellLocation[] LiveCellLocations { get; }
		IUniverse Evolve();
	}
}