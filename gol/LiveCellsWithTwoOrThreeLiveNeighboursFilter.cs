﻿using System.Collections.Generic;

namespace gol
{
	public class LiveCellsWithTwoOrThreeLiveNeighboursFilter : ICellLocationFilter
	{
		private readonly IUniverse _universe;

		public LiveCellsWithTwoOrThreeLiveNeighboursFilter(IUniverse universe)
		{
			_universe = universe;
		}

		public IEnumerable<ICellLocation> Filter()
		{
			return new CellsWithLiveNeighbourCountFilter(_universe.LiveCellLocations, 2, 3)
				.Filter(_universe.LiveCellLocations);
		}
	}
}