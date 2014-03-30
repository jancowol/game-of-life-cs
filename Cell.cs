using System.Collections.Generic;

namespace gol
{
	public class Cell : ICell
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Cell(int x, int y)
		{
			X = x;
			Y = y;
		}

		public IEnumerable<ICell> Neighbours()
		{
			return new[]
				{
					new Cell(X - 1, Y - 1), new Cell(X, Y - 1), new Cell(X + 1, Y - 1),
					new Cell(X - 1, Y), new Cell(X + 1, Y),
					new Cell(X - 1, Y + 1), new Cell(X, Y + 1), new Cell(X + 1, Y + 1)
				};
		}

		protected bool Equals(Cell other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Cell) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}
	}
}