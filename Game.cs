using System.Collections.Generic;

namespace gol
{
	public class Game
	{
		public Universe Evolve(Universe universe)
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

			return new Universe(evolvedCells);
		}
	}
}