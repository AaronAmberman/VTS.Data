using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using VTS.Data.Diagnostics;
using VTS.Data.Raw;

namespace VTS.File
{
    /// <summary>A custom file reader built for reading VTS mission files for VTOL VR.</summary>
    public class VtsReader
    {
        #region Methods

        private static void AdvancedLine(VtsFileLineData data, StreamReader sr)
        {
            data.Line = sr.ReadLine();
            data.LineNumber++;
            data.Data = data.Line.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            data.TabFreeData = data.Data == null ? null : data.Data.Length == 0 ? null : data.Data[0].Replace("\t", "").Trim();
            data.IndentDepth = data.Data == null ? -1 : data.Data.Length == 0 ? -1 : Regex.Match(data.Data[0], "\\t*").Groups[0].Length;
        }

        private static VtsObject ProcessObject(VtsBaseObject parent, VtsFileLineData data, StreamReader sr)
        {
            VtsObject child = new VtsObject
            {
                IndentDepth = data.IndentDepth,
                LineNumber = data.LineNumber,
                Name = data.TabFreeData,
                Parent = parent
            };

            while (!string.IsNullOrWhiteSpace(data.Line))
            {
                AdvancedLine(data, sr);

                if (data.TabFreeData == "{")
                    continue;
                else if (data.TabFreeData == "}")
                    // the object is at an end, return it
                    return child;
                else if (KeywordStrings.ObjectStrings.Contains(data.TabFreeData))
                {
                    // just in case a property name matches an object type name...
                    // let's make sure if its an object we only have 1 data point in data.Data and not 2 (because it was split at the '=')
                    if (data.Data.Length == 2)
                    {
                        child.Properties.Add(new VtsProperty
                        {
                            IndentDepth = data.IndentDepth,
                            LineNumber = data.LineNumber,
                            Name = data.TabFreeData,
                            Value = data.Data[1].Trim()
                        });
                    }
                    else
                        child.Children.Add(ProcessObject(child, data, sr));
                }
                else if (data.Data.Length == 2)
                {
                    child.Properties.Add(new VtsProperty
                    {
                        IndentDepth = data.IndentDepth,
                        LineNumber = data.LineNumber,
                        Name = data.TabFreeData,
                        Value = data.Data[1].Trim()
                    });
                }
            }

            return child;
        }

        private static void ProcessVtsFile(VtsCustomScenarioObject scenario, VtsFileLineData data, StreamReader sr)
        {
            while (!string.IsNullOrWhiteSpace(data.Line))
            {
                if (data.LineNumber == 1 && data.TabFreeData != KeywordStrings.CustomScenario)
                    throw new InvalidDataException("Cannot locate root object \"CustomScenario\". Invalid file.");
                else if (data.Data.Length == 2)
                {
                    scenario.Properties.Add(new VtsProperty
                    {
                        IndentDepth = data.IndentDepth,
                        LineNumber = data.LineNumber,
                        Name = data.TabFreeData,
                        Value = data.Data[1].Trim()
                    });
                }
                else if (data.Data.Length == 1 && KeywordStrings.ObjectStrings.Contains(data.TabFreeData))
                    scenario.Children.Add(ProcessObject(scenario, data, sr));
                else if (data.TabFreeData == "}")
                    return; // we have hit the final right brace

                AdvancedLine(data, sr);
            }
        }

        private static VtsCustomScenarioObject ReadFile(string file)
        {
            VtsFileLineData data = new VtsFileLineData();
            VtsCustomScenarioObject scenario = new VtsCustomScenarioObject
            {
                File = file,
                Name = KeywordStrings.CustomScenario
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        AdvancedLine(data, sr);

                        ProcessVtsFile(scenario, data, sr);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An exception occurred attempting to read the VTS file.{Environment.NewLine}{ex}");

                return new VtsCustomScenarioObject
                {
                    HasError = true
                };
            }

            sw.Stop();

            if (DiagnosticOptions.OutputReadWriteTimes)
                Debug.WriteLine($"VTS file read duration:{sw.Elapsed}");

            return scenario;
        }

        /// <summary>Reads the specified VTS file.</summary>
        /// <param name="file">The VTS file to read.</param>
        /// <returns>A VtsCustomScenario object containing the object graph from the VTS file.</returns>
        /// <exception cref="ArgumentNullException">The specified VTS file is null, empty or white-space characters.</exception>
        /// <exception cref="ArgumentException">The specified VTS file does not exist.</exception>
        /// <exception cref="InvalidDataException">The first line of the specified VTS file is not "CustomScenario".</exception>
        public static VtsCustomScenarioObject ReadVtsFile(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException(nameof(file));

            if (!System.IO.File.Exists(file))
                throw new ArgumentException("File must exist!");

            return ReadFile(file);
        }

        #endregion
    }
}
