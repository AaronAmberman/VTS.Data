namespace VTS.Data.Abstractions
{
    /// <summary>Represents a conditional action in the VTS file.</summary>
    public class ConditionalAction : ICloneable
    {
        #region Properties

        public Block BaseBlock { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ConditionalAction"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ConditionalAction object.</returns>
        public ConditionalAction Clone()
        {
            return new ConditionalAction
            {
                BaseBlock = BaseBlock.Clone(),
                Id = Id,
                Name = Name
            };
        }

        #endregion
    }
}
