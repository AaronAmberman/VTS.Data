namespace VTS.Data.Runtime
{
    /// <summary>An object to hold the unit group and that unit groups setting.</summary>
    public class UnitGroupGrouping : ICloneable
    {
        #region Properties

        public string Name { get; set; } // Alpha, Bravo, Charlie, etc.
        public UnitGroupSettings Settings { get; set; }
        public List<UnitSpawner> Units { get; set; } = new List<UnitSpawner>();

        public CustomScenario Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitGroupGrouping"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroupGrouping object.</returns>
        public UnitGroupGrouping Clone()
        {
            return new UnitGroupGrouping
            {
                Name = Name,
                Settings = Settings.Clone(),
                Units = Units.Select(x => x.Clone()).ToList()
            };
        }

        #endregion
    }
}
