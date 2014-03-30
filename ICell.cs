using System.Collections.Generic;

namespace gol
{
	public interface ICell
	{
		IEnumerable<ICell> AdjacentCells();
	}
}