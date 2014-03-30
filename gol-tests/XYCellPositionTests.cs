using NUnit.Framework;
using gol;

namespace gol_tests
{
	[TestFixture]
	public class XYCellPositionTests
	{
		[Test]
		public void ReturnsCorrectEightNeighbours()
		{
			var cell = new XYCellLocation(1, 1);
			var expectedNeighbours = new[]
				{
					new XYCellLocation(0, 0), new XYCellLocation(1, 0), new XYCellLocation(2, 0),
					new XYCellLocation(0, 1),							new XYCellLocation(2, 1),
					new XYCellLocation(0, 2), new XYCellLocation(1, 2), new XYCellLocation(2, 2)
				};

			Assert.That(
				cell.Neighbours(),
				Is.EquivalentTo(expectedNeighbours));
		}
	}
}