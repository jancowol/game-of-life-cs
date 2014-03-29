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
				if (liveCell.LiveNeighbourCount(universe.LiveCells) == 2)
				{
					evolvedCells.Add(liveCell);
				}
			}

			return new Universe(evolvedCells);
		}
	}
}