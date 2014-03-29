using System.Collections.Generic;

namespace gol
{
	public interface IUniverse
	{
		IEnumerable<ICell> LiveCells { get; }
	}
}