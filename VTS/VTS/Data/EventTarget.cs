namespace VTS.Data
{
    /// <summary>Represents an event target in VTOL VR.</summary>
    public class EventTarget
    {
        #region Properties

        public string EventName { get; set; }
        public string MethodName { get; set; }
        public List<ParamInfo> ParamInfos { get; set; } = new List<ParamInfo>();
        public int TargetId { get; set; }
        public string TargetType { get; set; }

        #endregion
    }
}
