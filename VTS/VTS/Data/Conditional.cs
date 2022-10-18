namespace VTS.Data
{
    /// <summary>Represents a conditional in VTOL VR.</summary>
    public class Conditional
    {
        #region Properties

        public List<Computation> Computations { get; set; } = new List<Computation>();
        public int Id { get; set; }
        public ThreePointValue OutputNodePosition { get; set; }
        public int Root { get; set; }

        #endregion
    }
}
