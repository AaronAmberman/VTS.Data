﻿namespace VTS.Data.Abstractions
{
    /// <summary>Represents a conditional in VTOL VR.</summary>
    public class Conditional : ICloneable
    {
        #region Properties

        public List<Computation> Computations { get; set; } = new List<Computation>();
        public int Id { get; set; }
        public string OutputNodePosition { get; set; }
        public int? Root { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Conditional"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Conditional object.</returns>
        public Conditional Clone()
        {
            return new Conditional
            {
                Computations = Computations.Select(x => x.Clone()).ToList(),
                OutputNodePosition = OutputNodePosition,
                Id = Id,
                Root = Root
            };
        }

        #endregion
    }
}
