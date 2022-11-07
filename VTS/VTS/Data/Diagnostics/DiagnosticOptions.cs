namespace VTS.Data.Diagnostics
{
    /// <summary>Allows the customization of diagnostic output when reading or writing a VTS file.</summary>
    public class DiagnosticOptions
    {
        #region Properties

        /// <summary>
        /// Gets or sets whether or not to output the unit fields to the debug window. 
        /// The output includes which units use that unit field "group". Default is false.
        /// </summary>
        public bool OutputUnitFieldsGroups { get; set; } = false;

        #endregion
    }
}
