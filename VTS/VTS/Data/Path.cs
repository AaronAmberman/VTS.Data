namespace VTS.Data
{
    /// <summary>Represents a path in VTOL VR.</summary>
    public class Path
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Loop { get; set; }
        public string PathMode { get; set; }
        public List<ThreePointValue> Points { get; set; } = new List<ThreePointValue>();

        #endregion
    }
}
