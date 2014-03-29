using System.Collections.Generic;

namespace gol
{
	public class FakeCell : ICell
	{
		private readonly ICell[] _neighbourCells;

		public FakeCell(params ICell[] neighbourCells)
		{
			_neighbourCells = neighbourCells;
		}

		public int LiveNeighbourCount(IEnumerable<ICell> cells)
		{
			return _neighbourCells.Length;
		}
	}
}