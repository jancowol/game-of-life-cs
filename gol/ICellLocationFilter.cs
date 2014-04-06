using System.Collections.Generic;

namespace gol
{
	public interface ICellLocationFilter
	{
		IEnumerable<ICellLocation> Filter(IUniverse universe);
	}
}