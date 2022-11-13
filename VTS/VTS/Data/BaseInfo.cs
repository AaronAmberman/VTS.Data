namespace VTS.Data
{
    /// <summary>Represents a base in VTOL VR.</summary>
    public class BaseInfo : ICloneable
    {
        #region Properties

        public int Id { get; set; }
        public string OverrideBaseName { get; set; }
        public string BaseTeam { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="BaseInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned BaseInfo object.</returns>
        public BaseInfo Clone()
        {
            return new BaseInfo
            {
                Id = Id,
                OverrideBaseName = OverrideBaseName,
                BaseTeam = BaseTeam
            };
        }

        #endregion
    }
}
