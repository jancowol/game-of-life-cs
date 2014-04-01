using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		IEnumerable<ICellLocation> LiveCellLocations { get; }
		IEnumerable<ICellLocation> DeadCellLocations { get; }
		int CellLiveNeighbourCount(ICellLocation cellLocation);
		IUniverse Evolve();
	}
}