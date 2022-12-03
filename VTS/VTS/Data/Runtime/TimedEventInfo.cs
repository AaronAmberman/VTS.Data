namespace VTS.Data.Runtime
{
    /// <summary>Represents a timed event info in VTOL VR.</summary>
    public class TimedEventInfo : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public List<EventTarget> EventTargets { get; set; } = new List<EventTarget>();
        public int Time { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="TimedEventInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TimedEventInfo object.</returns>
        public TimedEventInfo Clone()
        {
            return new TimedEventInfo
            {
                EventName = EventName, 
                EventTargets = EventTargets.Select(x => x.Clone()).ToList(),
                Time = Time
            };
        }

        #endregion
    }
}
