namespace VTS.Data
{
    /// <summary>Represents a trigger event in VTOL VR.</summary>
    public class TriggerEvent
    {
        #region Properties

        public int Conditional { get; set; }
        public bool Enabled { get; set; }
        public EventInfo EventInfo { get; set; }
        public string EventName { get; set; }
        public int Id { get; set; }
        public string ProxyMode { get; set; }
        public double Radius { get; set; }
        public bool SphericalRadius { get; set; }
        public string TriggerMode { get; set; }
        public string TriggerType { get; set; }
        public int Waypoint { get; set; }

        #endregion
    }
}
