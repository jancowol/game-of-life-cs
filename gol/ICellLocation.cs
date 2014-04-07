using System.Collections.Generic;

namespace gol
{
	public interface ICellLocation
	{
		IEnumerable<ICellLocation> Neighbours();
	}
}