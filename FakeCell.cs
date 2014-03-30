using System.Collections.Generic;

namespace gol
{
	public class FakeCell : ICell
	{
		private ICell[] _fakeNeighbours = new ICell[0];

		public FakeCell()
		{
		}

		public FakeCell(params ICell[] fakeNeighbours)
		{
			_fakeNeighbours = fakeNeighbours;
		}

		public void SetFakeNeighbours(ICell[] value)
		{
			_fakeNeighbours = value;
		}

		public IEnumerable<ICell> Neighbours()
		{
			return _fakeNeighbours;
		}
	}
}