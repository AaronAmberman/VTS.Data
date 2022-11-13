namespace VTS.Data
{
    /// <summary>Represents a param attr info object for a param info object.</summary>
    public class ParamAttrInfo : ICloneable
    {
        #region Properties

        public string Data { get; set; }
        public string Type { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ParamAttrInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ParamAttrInfo object.</returns>
        public ParamAttrInfo Clone()
        {
            return new ParamAttrInfo
            {
                Data = Data,
                Type = Type
            };
        }

        #endregion
    }
}
