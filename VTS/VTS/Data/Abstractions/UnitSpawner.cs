namespace VTS.Data.Abstractions
{
    /// <summary>Represents a unit in VTOL VR.</summary>
    public class UnitSpawner : ICloneable
    {
        #region Properties

        public string EditorPlacementMode { get; set; }
        public string GlobalPosition { get; set; }
        public string LastValidPlacement { get; set; }
        public string Rotation { get; set; }
        public int SpawnChance { get; set; }
        public string SpawnFlags { get; set; }
        public UnitFields UnitFields { get; set; }
        public string UnitId { get; set; }
        public int UnitInstanceId { get; set; }
        public string UnitName { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitSpawner"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitSpawner object.</returns>
        public UnitSpawner Clone()
        {
            return new UnitSpawner
            {
                EditorPlacementMode = EditorPlacementMode,
                GlobalPosition = GlobalPosition,
                LastValidPlacement = LastValidPlacement,
                Rotation = Rotation,
                SpawnChance = SpawnChance,
                SpawnFlags = SpawnFlags,
                UnitFields = UnitFields.Clone(),
                UnitId = UnitId,
                UnitInstanceId = UnitInstanceId,
                UnitName = UnitName
            };
        }

        #endregion
    }
}
