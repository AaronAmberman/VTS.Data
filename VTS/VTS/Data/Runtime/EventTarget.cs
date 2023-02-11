namespace VTS.Data.Runtime
{
    /// <summary>Represents an event target in VTOL VR.</summary>
    public class EventTarget : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public string MethodName { get; set; }
        public List<ParamInfo> ParamInfos { get; set; } = new List<ParamInfo>();
        // this could be a UnitSpawner, a UnitGroup, a TriggerEvent, a System value (like an int), a ConditionalAction, 
        // an Objective, a Sequence, a TimedEventGroup, a List<UnitSpawner>, a StaticObject
        public object Target { get; set; } 
        public string TargetType { get; set; }

        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="EventTarget"/> with all the same values as this instance.</summary>
        /// <returns>A cloned EventTarget object.</returns>
        public EventTarget Clone()
        {
            return new EventTarget
            {
                EventName = EventName,
                MethodName = MethodName,
                ParamInfos = ParamInfos.Select(x => x.Clone()).ToList(),
                // we cannot clone the target because the target may be a type that contains EventTargets, and those event
                // targets may reference a cloneable that has EventTargets and so on (this occurs when the Target is an
                // Objective with prerequisite Objectives)
                //Target = Target is ICloneable cloneable ? cloneable.Clone() : Target, // prefer clone, else just reference
                Target = Target,
                TargetType = TargetType,
                Parent = Parent
            };
        }

        #endregion
    }
}
