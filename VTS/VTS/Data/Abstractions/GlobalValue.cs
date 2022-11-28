namespace VTS.Data.Abstractions
{
    /// <summary>Represents a global value in VTOL VR.</summary>
    public class GlobalValue : ICloneable
    {
        #region Properties

        //public string Data { get; set; } // data = 1;MyValue;My value description;1234;
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="GlobalValue"/> with all the same values as this instance.</summary>
        /// <returns>A cloned GlobalValue object.</returns>
        public GlobalValue Clone()
        {
            return new GlobalValue
            {
                Index = Index,
                Name = Name,
                Description = Description,
                Value = Value
            };
        }

        public override string ToString()
        {
            return $"{Index};{Name};{Description};{Value};";
        }

        #endregion
    }
}
