namespace gol
{
	public interface IUniverse
	{
		ICellLocation[] LiveCellLocations { get; }
		ICellLocation[] DeadCellLocations { get; }
	}
}