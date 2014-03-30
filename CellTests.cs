using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class CellTests
	{
		[Test]
		public void ReturnsCorrectEightNeighbours()
		{
			var cell = new Cell(1, 1);
			var expectedNeighbours = new[]
				{
					new Cell(0, 0), new Cell(1, 0), new Cell(2, 0),
					new Cell(0, 1),                 new Cell(2, 1),
					new Cell(0, 2), new Cell(1, 2), new Cell(2, 2)
				};

			Assert.That(
				cell.Neighbours(),
				Is.EquivalentTo(expectedNeighbours));
		}
	}
}