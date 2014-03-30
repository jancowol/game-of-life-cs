﻿using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Game
	{
		public IUniverse Evolve(IUniverse universe)
		{
			var liveCells = new List<ICell>();

			liveCells.AddRange(LiveCellsWithTwoOrThreeLiveNeighbours(universe));
			liveCells.AddRange(DeadCellsWithThreeLiveNeighbours(universe));

			return new Universe(liveCells);
		}

		private static IEnumerable<ICell> DeadCellsWithThreeLiveNeighbours(IUniverse universe)
		{
			return universe.DeadCells
				.Where(deadCell =>
					{
						var neighbourCellPositions = deadCell.AdjacentCells();
						var liveNeighbourCount = neighbourCellPositions.Intersect(universe.LiveCells).Count();
						return liveNeighbourCount == 3;
					});
		}

		private static IEnumerable<ICell> LiveCellsWithTwoOrThreeLiveNeighbours(IUniverse universe)
		{
			return universe.LiveCells
				.Where(liveCell =>
					{
						var neighbourCellPositions = liveCell.AdjacentCells();
						var liveNeighbourCount = neighbourCellPositions.Intersect(universe.LiveCells).Count();
						return liveNeighbourCount == 2 || liveNeighbourCount == 3;
					});
		}
	}
}