using System.Collections.Generic;
using System.Linq;
using gol;

namespace gol_tests
{
	public class FakeCellLocation : ICellLocation
	{
		private ICellLocation[] _fakeNeighbours = new ICellLocation[0];

		public FakeCellLocation()
		{
		}

		public FakeCellLocation(params ICellLocation[] fakeNeighbours)
		{
			_fakeNeighbours = fakeNeighbours;
		}

		public void SetFakeNeighbours(ICellLocation[] value)
		{
			_fakeNeighbours = value;
		}

		public IEnumerable<ICellLocation> Neighbours()
		{
			return _fakeNeighbours;
		}

		public int CountOfNeighboursIn(IEnumerable<ICellLocation> cellLocations)
		{
			return Neighbours()
				.Intersect(cellLocations)
				.Count();
		}
	}
}