namespace VTS.Data
{
    /// <summary>Represents a settings object for a unit group (e.g. Alpha_SETTINGS, Bravo_SETTINGS, etc.).</summary>
    public class UnitGroupSettings : ICloneable
    {
        #region Properties

        public string Name { get; set; }
        public string SyncAltSpawns { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitGroupSettings"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroupSettings object.</returns>
        public UnitGroupSettings Clone()
        {
            return new UnitGroupSettings
            {
                Name = Name,
                SyncAltSpawns = SyncAltSpawns
            };
        }

        #endregion
    }
}
