using System.Diagnostics;

namespace VTS.Data.Raw
{
    /// <summary>Represents a property value on an object. A property has a name and a value.</summary>
    [DebuggerDisplay("{Name} = {Value}")]
    public class VtsProperty
    {
        #region Properties

        /// <summary>Get or sets the indent depth for the property.</summary>
        public int IndentDepth { get; set; }

        /// <summary>Get or sets the line number the property starts on.</summary>
        public int LineNumber { get; set; }

        /// <summary>Get or sets the name of the property.</summary>
        public string Name { get; set; }

        /// <summary>Get or sets the value of the property.</summary>
        public string Value { get; set; }

        #endregion
    }
}
