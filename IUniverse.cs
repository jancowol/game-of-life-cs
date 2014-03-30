using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		IEnumerable<ICell> LiveCells { get; }
		IEnumerable<ICell> DeadCells { get; }
		int CellLiveNeighbourCount(ICell cell);
	}
}