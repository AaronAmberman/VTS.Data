namespace VTS.Data
{
    /// <summary>Represents a static object in VTOL VR.</summary>
    public class StaticObject
    {
        #region Properties

        public string PrefabId { get; set; }
        public int Id { get; set; }
        public ThreePointValue GlobalPosition { get; set; }
        public ThreePointValue Rotation { get; set; }

        #endregion
    }
}
