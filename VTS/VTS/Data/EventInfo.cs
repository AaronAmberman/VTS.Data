namespace VTS.Data
{
    /// <summary>Represents a event info on a trigger event.</summary>
    public class EventInfo
    {
        #region Properties

        public string EventName { get; set; }
        public List<EventTarget> EventTargets { get; set; } = new List<EventTarget>();

        #endregion
    }
}
