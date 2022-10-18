namespace VTS.Data
{
    /// <summary>Represents an event sequence in VTOL VR.</summary>
    public class Sequence
    {
        #region Properties

        public List<Event> Events { get; set; } = new List<Event>();
        public int Id { get; set; }
        public string SequenceName { get; set; }
        public bool StartImmediately { get; set; }

        #endregion
    }
}
