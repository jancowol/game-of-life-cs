using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class CellsWithLiveNeighbourCountFilter
	{
		private readonly IEnumerable<ICellLocation> _liveCellLocations;
		private readonly int[] _filterNeighbourCounts;

		public CellsWithLiveNeighbourCountFilter(IEnumerable<ICellLocation> liveCellLocations, params int[] liveNeighbourCounts)
		{
			_liveCellLocations = liveCellLocations;
			_filterNeighbourCounts = liveNeighbourCounts;
		}

		public IEnumerable<ICellLocation> Filter(IEnumerable<ICellLocation> cellLocations)
		{
			var allNeighbours = AllNeighboursOf(cellLocations);
			var liveNeighbours = new HashSet<ICellLocation>(AllLiveCellLocationsIn(allNeighbours));

			foreach (var cellLocation in cellLocations)
			{
				var liveNeighbourCount = CountLiveNeighboursOf(cellLocation, liveNeighbours);

				if (_filterNeighbourCounts.Contains(liveNeighbourCount))
					yield return cellLocation;
			}
		}

		private static int CountLiveNeighboursOf(ICellLocation cellLocation, ISet<ICellLocation> liveNeighbours)
		{
			// The LINQ equivalent of this code performs slightly worse:
			// return cellLocation.Neighbours().Count(neighbour => liveNeighbours.Contains(neighbour));

			var count = 0;
			foreach (var neighbour in cellLocation.Neighbours())
				if (liveNeighbours.Contains(neighbour))
					count++;

			return count;
		}

		private IEnumerable<ICellLocation> AllLiveCellLocationsIn(IEnumerable<ICellLocation> allNeighbours)
		{
			return allNeighbours.Intersect(_liveCellLocations);
		}

		private static IEnumerable<ICellLocation> AllNeighboursOf(IEnumerable<ICellLocation> cellLocations)
		{
			return cellLocations.SelectMany(cl => cl.Neighbours());
		}
	}
}