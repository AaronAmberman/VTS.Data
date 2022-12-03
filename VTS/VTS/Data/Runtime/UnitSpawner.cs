namespace VTS.Data.Runtime
{
    /// <summary>Represents a unit in VTOL VR.</summary>
    public class UnitSpawner : ICloneable
    {
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

        public CustomScenario Parent { get; set; }

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
                GlobalPosition = GlobalPosition.Clone(),
                LastValidPlacement = LastValidPlacement.Clone(),
                Rotation = Rotation.Clone(),
                SpawnChance = SpawnChance,
                SpawnFlags = SpawnFlags,
                UnitFields = UnitFields.Clone(),
                UnitId = UnitId,
                UnitInstanceId = UnitInstanceId,
                UnitName = UnitName,
                Parent = Parent
            };
        }

        #endregion
    }
}
