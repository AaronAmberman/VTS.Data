namespace VTS.Data.Diagnostics
{
    /// <summary>Assists in grouping units and their collection of unit fields.</summary>
    public class UnitUnitFieldGrouping
    {
        public IReadOnlyList<string> Units { get; set; } = new List<string>();
        public IReadOnlyList<string> UnitFields { get; set; } = new List<string>();
    }
}
