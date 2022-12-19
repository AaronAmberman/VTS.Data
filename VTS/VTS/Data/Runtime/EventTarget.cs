namespace VTS.Data.Runtime
{
    /// <summary>Represents an event target in VTOL VR.</summary>
    public class EventTarget : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public string MethodName { get; set; }
        public List<ParamInfo> ParamInfos { get; set; } = new List<ParamInfo>();
        // this could be a UnitSpawner, a UitGroup, a TriggerEvent, a System value, ?
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
                Target = Target is ICloneable cloneable ? cloneable.Clone() : Target, // prefer clone, else just mae reference
                TargetType = TargetType,
                Parent = Parent
            };
        }

        #endregion
    }
}
