using System.Collections.Generic;

namespace gol
{
	public class Cell : ICell
	{
		private readonly int _x;
		private readonly int _y;

		public Cell(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public IEnumerable<ICell> AdjacentCells()
		{
			return new[]
				{
					new Cell(_x - 1, _y - 1), new Cell(_x, _y - 1), new Cell(_x + 1, _y - 1),
					new Cell(_x - 1, _y), new Cell(_x + 1, _y),
					new Cell(_x - 1, _y + 1), new Cell(_x, _y + 1), new Cell(_x + 1, _y + 1)
				};
		}

		protected bool Equals(Cell other)
		{
			return _x == other._x && _y == other._y;
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
				return (_x*397) ^ _y;
			}
		}
	}
}