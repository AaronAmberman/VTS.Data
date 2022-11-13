namespace VTS.Data
{
    /// <summary>Represents a timed event group in VTOL VR.</summary>
    public class TimedEventGroup : ICloneable
    {
        #region Properties

        public bool BeginImmediately { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int InitialDelay { get; set; }
        public List<TimedEventInfo> TimedEventInfos { get; set; } = new List<TimedEventInfo>();

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="TimedEventGroup"/> with all the same values as this instance.</summary>
        /// <returns>A cloned TimedEventGroup object.</returns>
        public TimedEventGroup Clone()
        {
            return new TimedEventGroup
            {
                BeginImmediately = BeginImmediately,
                GroupId = GroupId,
                GroupName = GroupName,
                InitialDelay = InitialDelay,
                TimedEventInfos = TimedEventInfos.Select(x => x.Clone()).ToList()
            };
        }

        #endregion
    }
}
