namespace VTS.Data.Raw
{
    /// <summary>An abstract base class for VTS objects.</summary>
    public abstract class VtsBaseObject
    {
        #region Properties

        /// <summary>Get or sets the collection of children the object has.</summary>
        public List<VtsObject> Children { get; set; }

        /// <summary>Get or sets the name of the object.</summary>
        public string Name { get; set; }

        /// <summary>Get or sets the collection of properties for the object.</summary>
        public List<VtsProperty> Properties { get; set; }

        #endregion
    }
}
