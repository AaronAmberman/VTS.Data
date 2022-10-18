namespace VTS.Data
{
    /// <summary>Represents an objective in VTOL VR.</summary>
    public class Objective
    {
        #region Properties

        public string AutoSetWaypoint { get; set; }
        public string CompletionReward { get; set; }
        public ObjectiveFields Fields { get; set; }
        public string ObjectiveInfo { get; set; }
        public string ObjectiveID { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveType { get; set; }
        public string OrderID { get; set; }
        public string Required { get; set; }
        public string PreReqObjectives { get; set; }
        public string StartMode { get; set; }
        public string Waypoint { get; set; }
        public EventInfo CompleteEvent { get; set; }
        public EventInfo FailEvent { get; set; }
        public EventInfo StartEvent { get; set; }

        #endregion
    }
}
