namespace gol
{
	public class Game
	{
		public Universe Evolve(Universe universe)
		{
			if (universe.LiveCells.Length == 1)
				return new Universe();

			return new Universe(universe.LiveCells);
		}
	}
}