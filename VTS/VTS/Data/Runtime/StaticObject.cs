namespace VTS.Data.Runtime
{
    /// <summary>Represents a static object in VTOL VR.</summary>
    public class StaticObject : ICloneable
    {
        #region Properties

        public string PrefabId { get; set; }
        public int Id { get; set; }
        public ThreePointValue GlobalPosition { get; set; }
        public ThreePointValue Rotation { get; set; }

        public CustomScenario Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="StaticObject"/> with all the same values as this instance.</summary>
        /// <returns>A cloned StaticObject object.</returns>
        public StaticObject Clone()
        {
            return new StaticObject
            {
                PrefabId = PrefabId,
                Id = Id,
                GlobalPosition = GlobalPosition.Clone(),
                Rotation = Rotation.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
