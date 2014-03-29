using System.Linq;

namespace gol
{
	public class Game
	{
		public Universe Evolve(Universe universe)
		{
			if (universe.LiveCells.Count() == 1)
				return new Universe();

			return new Universe(universe.LiveCells);
		}
	}
}