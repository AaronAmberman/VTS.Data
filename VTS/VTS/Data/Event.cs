namespace VTS.Data
{
    /// <summary>Represents an event for an event sequence.</summary>
    public class Event : ICloneable
    {
        #region Properties

        public int Conditional { get; set; }
        public int Delay { get; set; }
        public EventInfo EventInfo { get; set; }
        public int ExitConditional { get; set; }
        public string NodeName { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Event"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Event object.</returns>
        public Event Clone()
        {
            return new Event
            {
                Conditional = Conditional,
                Delay = Delay,
                EventInfo = EventInfo.Clone(),
                ExitConditional = ExitConditional,
                NodeName = NodeName,
            };
        }

        #endregion
    }
}
