using System.Diagnostics;

namespace VTS.Data.Raw
{
    /// <summary>Represents a CustomScenario object.</summary>
    [DebuggerDisplay("VTS File:{File}")]
    public class VtsCustomScenarioObject : VtsBaseObject
    {
        #region Properties

        /// <summary>Gets or sets whether or not there was an error reading or writing the VTS file.</summary>
        public bool HasError { get; set; }

        /// <summary>Get or sets the file for the CustomScenario object.</summary>
        public string File { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VtsCustomScenarioObject" /> class.</summary>
        public VtsCustomScenarioObject()
        {
            Children = new List<VtsObject>();
            Properties = new List<VtsProperty>();
        }

        #endregion
    }
}
