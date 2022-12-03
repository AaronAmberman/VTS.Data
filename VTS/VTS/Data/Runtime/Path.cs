namespace VTS.Data.Runtime
{
    /// <summary>Represents a path in VTOL VR.</summary>
    public class Path : ICloneable
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Loop { get; set; }
        public string PathMode { get; set; }
        public List<ThreePointValue> Points { get; set; } = new List<ThreePointValue>();

        public CustomScenario Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Path"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Path object.</returns>
        public Path Clone()
        {
            return new Path
            {
                Id = Id,
                Name = Name,
                Loop = Loop,
                PathMode = PathMode,
                Points = Points.Select(x => x.Clone()).ToList(),
                Parent = Parent
            };
        }

        #endregion
    }
}
