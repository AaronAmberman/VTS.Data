namespace VTS.Data
{
    /// <summary>Represents a location in a 3D space.</summary>
    public class ThreePointValue : ICloneable
    {
        #region Properties

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ThreePointValue"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ThreePointValue object.</returns>
        public ThreePointValue Clone()
        {
            return new ThreePointValue
            {
                X = X,
                Y = Y,
                Z = Z
            };
        }

        public override string ToString()
        {
            // todo : If I can ever figure out which string format was used for some of the outputs
            //        then we could match the output of the file exactly but I cannot seem to get it
            //        to match all outputs. Specifically I cannot get the ones that have up to 15
            //        decimals to match the file output exactly. The general .ToString does a better
            //        job than any of the custom formats I tried.
            return $"({X}, {Y}, {Z})";
        }

        #endregion
    }
}
