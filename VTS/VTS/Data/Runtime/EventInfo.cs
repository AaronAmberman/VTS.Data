namespace VTS.Data.Runtime
{
    /// <summary>Represents a event info on a trigger event.</summary>
    public class EventInfo : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public List<EventTarget> EventTargets { get; set; } = new List<EventTarget>();

        // can be a Block, a TriggerEvent, Objective or a Sequence
        public object Parent { get; set; }

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
                EventTargets = EventTargets.Select(x => x.Clone()).ToList(),
                Parent = Parent
            };
        }

        #endregion
    }
}
