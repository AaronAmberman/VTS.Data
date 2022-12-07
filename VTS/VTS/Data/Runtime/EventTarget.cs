﻿namespace VTS.Data.Runtime
{
    /// <summary>Represents an event target in VTOL VR.</summary>
    public class EventTarget : ICloneable
    {
        #region Properties

        public string EventName { get; set; }
        public string MethodName { get; set; }
        public List<ParamInfo> ParamInfos { get; set; } = new List<ParamInfo>();
        //public int TargetId { get; set; }
        public UnitSpawner Target { get; set; } // UnitSpawner.UnitInstanceId is TargetId when making Abstraction equivalent 
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
                //TargetId = TargetId,
                Target = Target.Clone(),
                TargetType = TargetType,
                Parent = Parent
            };
        }

        #endregion
    }
}