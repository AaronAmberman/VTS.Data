using System.Diagnostics;
using VTS.Data.Raw;

namespace VTS.Data.Diagnostics
{
    /// <summary>Assists in diagnostic output when reading or writing a VTS file.</summary>
    public static class VtsDiagnosticHelper
    {
        public static List<Tuple<VtsObject, VtsObject>> UnitAndFields { get; set; } = new List<Tuple<VtsObject, VtsObject>>();
        private static List<Tuple<VtsObject, List<string>>> UnitAndFieldProperties { get; set; } = new List<Tuple<VtsObject, List<string>>>();
        private static List<Tuple<string, List<string>>> UnitNameAndFieldProperties { get; set; } = new List<Tuple<string, List<string>>>();
        private static List<Tuple<List<string>, List<string>>> UnitNamesAndFieldProperties { get; set; } = new List<Tuple<List<string>, List<string>>>();

        public static void OutputUnitFieldGroups()
        {
            UnitAndFieldProperties.Clear();
            UnitNameAndFieldProperties.Clear();
            UnitNamesAndFieldProperties.Clear();

            foreach (Tuple<VtsObject, VtsObject> unitUnitFields in UnitAndFields)
            {
                List<string> properties = new List<string>();

                VtsProperty nameProperty = unitUnitFields.Item1.Properties.FirstOrDefault(p => p.Name == "unitID");
                VtsProperty unitGroupProperty = unitUnitFields.Item2.Properties.FirstOrDefault(p => p.Name == "unitGroup");

                foreach (VtsProperty property in unitUnitFields.Item2.Properties)
                {
                    properties.Add(property.Name);
                }

                string name = nameProperty.Value;

                UnitAndFieldProperties.Add(new Tuple<VtsObject, List<string>>(unitUnitFields.Item1, properties));
                UnitNameAndFieldProperties.Add(new Tuple<string, List<string>>(name, properties));
            }

            foreach (Tuple<string, List<string>> properties in UnitNameAndFieldProperties)
            {
                if (UnitNamesAndFieldProperties.Count == 0)
                {
                    UnitNamesAndFieldProperties.Add(new Tuple<List<string>, List<string>>(new List<string> { properties.Item1 }, properties.Item2));

                    continue;
                }

                bool? match = null;

                foreach (Tuple<List<string>, List<string>> distinctProperties in UnitNamesAndFieldProperties)
                {
                    if (distinctProperties.Item2.SequenceEqual(properties.Item2)) // matching sequence
                    {
                        if (!distinctProperties.Item1.Contains(properties.Item1))
                            distinctProperties.Item1.Add(properties.Item1);

                        match = true;

                        break;
                    }
                    else // no matching sequence
                    {
                        match = false;
                    }
                }

                if (!match.Value)
                {
                    UnitNamesAndFieldProperties.Add(new Tuple<List<string>, List<string>>(new List<string> { properties.Item1 }, properties.Item2));
                }
            }



            foreach (Tuple<List<string>, List<string>> properties in UnitNamesAndFieldProperties)
            {
                string names = string.Join(',', properties.Item1.OrderBy(x => x));

                Debug.WriteLine(names);

                foreach (string property in properties.Item2)
                {
                    Debug.WriteLine(property);
                }

                Debug.WriteLine("");
                Debug.WriteLine("");
            }

            UnitAndFields.Clear();
        }
    }
}
