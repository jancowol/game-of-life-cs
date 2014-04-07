using System;
using System.Collections.Generic;

namespace gol
{
	public class XYCellLocation : ICellLocation
	{
		private readonly int _hashCode;
		private ICellLocation[] _neighbours;
		public int X { get; private set; }
		public int Y { get; private set; }

		private static Dictionary<Tuple<int, int>, XYCellLocation> _locationCache = new Dictionary<Tuple<int, int>, XYCellLocation>();

		private static XYCellLocation LocationAt(int x, int y)
		{
			XYCellLocation location;
			var key = new Tuple<int, int>(x, y);
			if (!_locationCache.TryGetValue(key, out location))
			{
				location = new XYCellLocation(x, y);
				_locationCache.Add(key, location);
			}
			return location;
		}

		public XYCellLocation(int x, int y)
		{
			X = x;
			Y = y;
			unchecked
			{
				_hashCode = (X*397) ^ Y;
			}
		}

		public IEnumerable<ICellLocation> Neighbours()
		{
			if (_neighbours == null)
			{
				_neighbours = new[]
					{
						LocationAt(X - 1, Y - 1), LocationAt(X, Y - 1), LocationAt(X + 1, Y - 1),
						LocationAt(X - 1, Y), LocationAt(X + 1, Y),
						LocationAt(X - 1, Y + 1), LocationAt(X, Y + 1), LocationAt(X + 1, Y + 1)
					};
			}

			return _neighbours;
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
			return _hashCode;
		}
	}
}