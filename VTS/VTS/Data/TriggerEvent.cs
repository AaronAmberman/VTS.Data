namespace VTS.Data
{
    /// <summary>Represents a trigger event in VTOL VR.</summary>
    public class TriggerEvent : ICloneable
    {
        #region Properties

        public int? Conditional { get; set; }
        public bool Enabled { get; set; }
        public EventInfo EventInfo { get; set; }
        public string EventName { get; set; }
        public int Id { get; set; }
        public string ProxyMode { get; set; }
        public float? Radius { get; set; }
        public bool? SphericalRadius { get; set; }
        public string TriggerMode { get; set; }
        public string TriggerType { get; set; }
        public int? Waypoint { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="TriggerEvent"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TriggerEvent object.</returns>
        public TriggerEvent Clone()
        {
            return new TriggerEvent
            {
                Conditional = Conditional,
                Enabled = Enabled,
                EventInfo = EventInfo.Clone(),
                EventName = EventName,
                Id = Id,
                ProxyMode = ProxyMode,
                Radius = Radius,
                SphericalRadius = SphericalRadius,
                TriggerMode = TriggerMode,
                TriggerType = TriggerType,
                Waypoint = Waypoint
            };
        }

        #endregion
    }
}
