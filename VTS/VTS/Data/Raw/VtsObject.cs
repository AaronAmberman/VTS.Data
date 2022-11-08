using System.Diagnostics;

namespace VTS.Data.Raw
{
    /// <summary>
    /// Represents a generic object in the VTS file. This can be a UnitSpawner, TriggerEvent, TimeEventGroup, 
    /// WAYPOINTS, PATHS, etc. (any object in the list of objects in the keyword strings file). 
    /// </summary>
    [DebuggerDisplay("Parent:{Parent} | Name:{Name}")]
    public class VtsObject : VtsBaseObject
    {
        #region Properties

        /// <summary>Get or sets the indent depth for the object. This will need to be set for writing. Filled in on read.</summary>
        public int IndentDepth { get; set; }

        /// <summary>Get or sets the line number the object starts on. This is not used for writing. Filled in on read.</summary>
        public int LineNumber { get; set; }

        /// <summary>Get or sets the parent of the object.</summary>
        public VtsBaseObject Parent { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VtsObject" /> class.</summary>
        public VtsObject()
        {
            Children = new List<VtsObject>();
            Properties = new List<VtsProperty>();
        }

        #endregion
    }
}
