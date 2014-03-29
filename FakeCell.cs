﻿using System.Collections.Generic;

namespace gol
{
	public class FakeCell : ICell
	{
		private readonly ICell[] _adjacentCells;
		private readonly int _liveNeighbourCount;

		public FakeCell(int liveNeighbourCount = 0)
		{
			_liveNeighbourCount = liveNeighbourCount;
			_adjacentCells = new ICell[0];
		}

		public FakeCell(params ICell[] adjacentCells)
		{
			_adjacentCells = adjacentCells;
		}

		public int NumberOfNeighboursIn(IEnumerable<ICell> cells)
		{
			return _liveNeighbourCount;
		}

		public IEnumerable<ICell> AdjacentCells()
		{
			return _adjacentCells;
		}
	}
}