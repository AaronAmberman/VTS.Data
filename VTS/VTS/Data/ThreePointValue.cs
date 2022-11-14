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
            return $"({X}, {Y}, {Z})";
        }

        #endregion
    }
}
