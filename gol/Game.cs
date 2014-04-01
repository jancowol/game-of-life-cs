namespace gol
{
	public class Game
	{
		public IUniverse Tick(IUniverse universe)
		{
			return universe.Evolve();
		}
	}
}