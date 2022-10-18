namespace VTS.Data
{
    /// <summary>Represents a param info object.</summary>
    public class ParamInfo
    {
        #region Properties

        public string Name { get; set; }
        public List<ParamAttrInfo> ParamAttrInfos { get; set; } = new List<ParamAttrInfo>();
        public string Type { get; set; }
        public string Value { get; set; }

        #endregion
    }
}
