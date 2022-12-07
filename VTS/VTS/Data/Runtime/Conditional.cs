namespace VTS.Data.Runtime
{
    /// <summary>Represents a conditional in VTOL VR.</summary>
    public class Conditional : ICloneable
    {
        #region Properties

        public List<Computation> Computations { get; set; } = new List<Computation>();
        public int Id { get; set; }
        public ThreePointValue OutputNodePosition { get; set; }
        public int? Root { get; set; }

        // can be a CustomScenario (in the conditionals collection), Block or an Event
        public object Parent { get; set; }

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
                OutputNodePosition = OutputNodePosition.Clone(),
                Id = Id,
                Root = Root,
                Parent = Parent
            };
        }

        #endregion
    }
}
