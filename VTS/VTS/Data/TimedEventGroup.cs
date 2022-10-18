namespace VTS.Data
{
    /// <summary>Represents a timed event group in VTOL VR.</summary>
    public class TimedEventGroup
    {
        #region Properties

        public bool BeginImmediately { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int InitialDelay { get; set; }
        public List<TimedEventInfo> TimedEventGroups { get; set; } = new List<TimedEventInfo>();

        #endregion
    }
}
