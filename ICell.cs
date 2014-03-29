using System.Collections.Generic;

namespace gol
{
	public interface ICell
	{
		int NumberOfNeighboursIn(IEnumerable<ICell> cells);
		IEnumerable<ICell> AdjacentCells();
	}
}