namespace VTS.Data.Abstractions
{
    /// <summary>Represents a waypoint in VTOL VR.</summary>
    public class Waypoint : ICloneable
    {
        #region Properties

        public string GlobalPoint { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Waypoint"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitSpawner object.</returns>
        public Waypoint Clone()
        {
            return new Waypoint
            {
                GlobalPoint = GlobalPoint,
                Id = Id,
                Name = Name
            };
        }

        #endregion
    }
}
