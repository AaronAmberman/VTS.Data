namespace VTS.Data
{
    /// <summary>Represents a timed event info in VTOL VR.</summary>
    public class TimedEventInfo
    {
        #region Properties

        public string EventName { get; set; }
        public List<EventTarget> EventTargets { get; set; } = new List<EventTarget>();
        public int Time { get; set; }

        #endregion
    }
}
