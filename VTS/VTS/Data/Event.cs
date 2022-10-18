namespace VTS.Data
{
    /// <summary>Represents an event for an event sequence.</summary>
    public class Event
    {
        #region Properties

        public int Conditional { get; set; }
        public int Delay { get; set; }
        public EventInfo EventInfo { get; set; }
        public int ExitConditional { get; set; }
        public string NodeName { get; set; }

        #endregion
    }
}
