﻿namespace VTS.Data.Runtime
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
        public List<Objective> PreReqObjectives { get; set; } = new List<Objective>();
        public string StartMode { get; set; }
        public object Waypoint { get; set; }
        public EventInfo CompleteEvent { get; set; }
        public EventInfo FailEvent { get; set; }
        public EventInfo StartEvent { get; set; }

        public CustomScenario Parent { get; set; }

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
                // we cannot clone the prerequisite objectives because it will lead to a StackOverflowException
                // as the objectives will just start to circularly clone each other if referenced on an EventTarget
                // as the Target, just reference
                //PreReqObjectives = PreReqObjectives.Select(x => x.Clone()).ToList(),
                PreReqObjectives = PreReqObjectives,
                StartMode = StartMode,
                Waypoint = Waypoint is ICloneable cloneable ? cloneable.Clone() : Waypoint, // prefer clone, else just reference
                CompleteEvent = CompleteEvent.Clone(),
                FailEvent = FailEvent.Clone(),
                StartEvent = StartEvent.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
