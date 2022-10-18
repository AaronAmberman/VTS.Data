namespace VTS.Data
{
    /// <summary>Represents a waypoint in VTOL VR.</summary>
    public class Waypoint
    {
        #region Properties

        public ThreePointValue GlobalPoint { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion
    }
}
