namespace VTS.Data.Diagnostics
{
    /// <summary>Allows the customization of diagnostic output when reading or writing a VTS file.</summary>
    public static class DiagnosticOptions
    {
        #region Properties

        /// <summary>
        /// Gets or sets whether or not to output the conversion time for the custom scenario
        /// when converting between Abstractions.CustomScenario and Runtime.CustomScenario.
        /// </summary>
        public static bool OutputCustomScenarioConversionTime { get; set; }

        /// <summary>
        /// Gets or sets whether or not to output the read and write times for the various 
        /// readers and writers within this API.
        /// </summary>
        public static bool OutputReadWriteTimes { get; set; }

        /// <summary>
        /// Gets or sets whether or not to output the unit fields to the debug window. 
        /// The output includes which units use that unit field "group".
        /// </summary>
        public static bool OutputUnitFieldsGroups { get; set; }

        #endregion
    }
}
