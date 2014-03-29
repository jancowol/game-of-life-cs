namespace gol
{
	public class Universe
	{
		public object[] LiveCells { get; set; }

		public Universe(params Cell[] liveCells)
		{
			LiveCells = new object[0];
		}
	}
}