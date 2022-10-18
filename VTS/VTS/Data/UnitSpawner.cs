namespace VTS.Data
{
    /// <summary>Represents a unit in VTOL VR.</summary>
    public class UnitSpawner
    {
        #region Fields

        #endregion

        #region Properties

        public string EditorPlacementMode { get; set; }
        public ThreePointValue GlobalPosition { get; set; }
        public ThreePointValue LastValidPlacement { get; set; }
        public ThreePointValue Rotation { get; set; }
        public int SpawnChance { get; set; }
        public string SpawnFlags { get; set; }
        public UnitFields UnitFields { get; set; }
        public string UnitId { get; set; }
        public int UnitInstanceId { get; set; }
        public string UnitName { get; set; }

        #endregion
    }
}
