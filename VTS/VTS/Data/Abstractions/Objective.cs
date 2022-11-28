namespace VTS.Data.Abstractions
{
    /// <summary>Represents an objective in VTOL VR.</summary>
    public class Objective : ICloneable
    {
        #region Properties

        public bool AutoSetWaypoint { get; set; }
        public int CompletionReward { get; set; }
        public ObjectiveFields Fields { get; set; }
        public string ObjectiveInfo { get; set; }
        public int ObjectiveID { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveType { get; set; }
        public int OrderID { get; set; }
        public bool Required { get; set; }
        public string PreReqObjectives { get; set; }
        public string StartMode { get; set; }
        public string Waypoint { get; set; }
        public EventInfo CompleteEvent { get; set; }
        public EventInfo FailEvent { get; set; }
        public EventInfo StartEvent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Objective"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Objective object.</returns>
        public Objective Clone()
        {
            return new Objective
            {
                AutoSetWaypoint = AutoSetWaypoint,
                CompletionReward = CompletionReward,
                Fields = Fields.Clone(),
                ObjectiveInfo = ObjectiveInfo,
                ObjectiveID = ObjectiveID,
                ObjectiveName = ObjectiveName,
                ObjectiveType = ObjectiveType,
                OrderID = OrderID,
                Required = Required,
                PreReqObjectives = PreReqObjectives,
                StartMode = StartMode,
                Waypoint = Waypoint,
                CompleteEvent = CompleteEvent.Clone(),
                FailEvent = FailEvent.Clone(),
                StartEvent = StartEvent.Clone()
            };
        }

        #endregion
    }
}
