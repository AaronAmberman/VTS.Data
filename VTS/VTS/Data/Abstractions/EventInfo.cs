namespace VTS.Data.Abstractions
{
    /// <summary>Represents a event info on a trigger event.</summary>
    public class EventInfo : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public List<EventTarget> EventTargets { get; set; } = new List<EventTarget>();

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="EventInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned EventInfo object.</returns>
        public EventInfo Clone()
        {
            return new EventInfo
            {
                EventName = EventName,
                EventTargets = EventTargets.Select(x => x.Clone()).ToList()
            };
        }

        #endregion
    }
}
