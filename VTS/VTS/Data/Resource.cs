namespace VTS.Data
{
    /// <summary>Represents a resource in the resource manifest for the VTS file.</summary>
    public class Resource : ICloneable
    {
        #region Properties

        public int Index { get; set; }
        public string Path { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Resource"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Resource object.</returns>
        public Resource Clone()
        {
            return new Resource
            {
                Index = Index,
                Path = Path
            };
        }

        #endregion
    }
}
