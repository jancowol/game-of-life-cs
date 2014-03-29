using System.Collections.Generic;

namespace gol
{
	public class Game
	{
		public FakeUniverse Evolve(FakeUniverse universe)
		{
			var evolvedCells = new List<ICell>();

			foreach (var liveCell in universe.LiveCells)
			{
				var liveNeighbourCount = liveCell.LiveNeighbourCount(universe.LiveCells);
				if (liveNeighbourCount == 2 || liveNeighbourCount == 3)
				{
					evolvedCells.Add(liveCell);
				}
			}

			foreach (var deadCell in universe.DeadCells)
			{
				if (deadCell.LiveNeighbourCount(universe.LiveCells) == 3)
				{
					evolvedCells.Add(deadCell);
				}
			}

			return new FakeUniverse(evolvedCells);
		}
	}
}