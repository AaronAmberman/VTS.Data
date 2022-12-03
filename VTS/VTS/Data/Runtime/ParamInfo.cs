namespace VTS.Data.Runtime
{
    /// <summary>Represents a param info object.</summary>
    public class ParamInfo : ICloneable
    {
        #region Properties

        public string Name { get; set; }
        public List<ParamAttrInfo> ParamAttrInfos { get; set; } = new List<ParamAttrInfo>();
        public string Type { get; set; }
        public string Value { get; set; }

        public EventTarget Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ParamInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ParamInfo object.</returns>
        public ParamInfo Clone()
        {
            return new ParamInfo
            {
                Name = Name,
                ParamAttrInfos = ParamAttrInfos.Select(x => x.Clone()).ToList(),
                Type = Type,
                Value = Value,
                Parent = Parent
            };
        }

        #endregion
    }
}
