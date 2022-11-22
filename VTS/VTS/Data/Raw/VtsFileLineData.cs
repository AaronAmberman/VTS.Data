namespace VTS.Data.Raw
{
    /// <summary>Represents a line of data in the VTS file.</summary>
    public class VtsFileLineData
    {
        /// <summary>
        /// Get or sets the data for the line. For lines with an '=' in them there will be 
        /// 2 data points. For all others there will only be 1.
        /// </summary>
        public string[] Data { get; set; }

        /// <summary>Get or sets the tab free data for Data[0]. This will be object names and property names.</summary>
        public string TabFreeData { get; set; }

        /// <summary>Get or sets the indent depth for the line.</summary>
        public int IndentDepth { get; set; }

        /// <summary>Get or sets the line from the VTS file.</summary>
        public string Line { get; set; }

        /// <summary>Get or sets the line number for the line of text. This is filled in on read and is not used on write.</summary>
        public int LineNumber { get; set; }
    }
}
