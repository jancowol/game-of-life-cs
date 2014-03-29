using System.Collections.Generic;

namespace gol
{
	public interface ICell
	{
		int LiveNeighbourCount(IEnumerable<ICell> cells);
		IEnumerable<ICell> AdjacentCells();
	}
}