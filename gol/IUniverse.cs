using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		IEnumerable<ICellLocation> LiveCellLocations { get; }
		IUniverse Evolve();
	}
}