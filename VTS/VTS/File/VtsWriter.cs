using System.Diagnostics;
using System.Text;
using VTS.Data.Diagnostics;
using VTS.Data.Raw;

namespace VTS.File
{
    /// <summary>A custom file writer built for writing VTS mission files for VTOL VR.</summary>
    public static class VtsWriter
    {
        #region Methods

        /// <summary>Writes the scenario object to a VTS file.</summary>
        /// <param name="scenario">VtsCustomScenarioObject to write to a file.</param>
        /// <param name="file">The absolute path to the file being written or replaced.</param>
        /// <returns>True if successfully written otherwise false.</returns>
        public static bool WriteVtsFile(VtsCustomScenarioObject scenario, string file)
        {
            if (scenario == null) 
                throw new ArgumentNullException(nameof(scenario));

            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!System.IO.File.Exists(file))
                throw new ArgumentException("File must exist!");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                // make sure to write a standard UTF8 file not a UTF8+BOM
                using (StreamWriter sw = new StreamWriter(file, false, new UTF8Encoding(false)))
                {
                    sw.Write(KeywordStrings.CustomScenario + "\n");
                    sw.Write("{\n");

                    // write properties for CustomScenario
                    foreach (VtsProperty property in scenario.Properties)
                    {
                        // properties for the CustomScenario object are 1 tab in always
                        sw.Write($"\t{property.Name} = {property.Value}\n");
                    }

                    // write object graph
                    foreach (VtsObject child in scenario.Children)
                    {
                        WriteObject(child, sw);
                    }

                    sw.Write("}\n");
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An exception occurred attempting to write the VTS file.{Environment.NewLine}{ex}");

                scenario.HasError = true;

                return false;
            }

            stopWatch.Stop();

            if (DiagnosticOptions.OutputReadWriteTimes)
                Debug.WriteLine($"VTS file write duration:{stopWatch.Elapsed}");

            return true;
        }

        private static void WriteObject(VtsObject obj, StreamWriter sw)
        {
            // build tab indent for line
            string tabString = string.Empty;
            string propertyTabString = string.Empty;

            for (int i = 0; i < obj.IndentDepth; i++)
                tabString += "\t";

            for (int i = 0; i < obj.IndentDepth + 1; i++)
                propertyTabString += "\t";

            sw.Write($"{tabString}{obj.Name}\n");
            sw.Write(tabString + "{\n");

            // write all the properties first then the child objects
            foreach (VtsProperty property in obj.Properties)
            {
                sw.Write($"{propertyTabString}{property.Name} = {property.Value}\n");
            }

            foreach (VtsObject child in obj.Children)
            {
                WriteObject(child, sw);
            }

            sw.Write(tabString + "}\n");
        }

        #endregion
    }
}
