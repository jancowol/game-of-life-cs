namespace gol
{
	public class Universe
	{
		public Cell[] LiveCells { get; set; }

		public Universe(params Cell[] liveCells)
		{
			LiveCells = liveCells;
		}
	}
}