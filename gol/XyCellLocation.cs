using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class XYCellLocation : ICellLocation
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public XYCellLocation(int x, int y)
		{
			X = x;
			Y = y;
		}

		public IEnumerable<ICellLocation> Neighbours()
		{
			return new[]
				{
					new XYCellLocation(X - 1, Y - 1), new XYCellLocation(X, Y - 1), new XYCellLocation(X + 1, Y - 1),
					new XYCellLocation(X - 1, Y),									new XYCellLocation(X + 1, Y),
					new XYCellLocation(X - 1, Y + 1), new XYCellLocation(X, Y + 1), new XYCellLocation(X + 1, Y + 1)
				};
		}

		protected bool Equals(XYCellLocation other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((XYCellLocation) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}

		public int CountOfNeighboursIn(IEnumerable<ICellLocation> cellLocations)
		{
			return Neighbours()
				.Intersect(cellLocations)
				.Count();
		}
	}
}