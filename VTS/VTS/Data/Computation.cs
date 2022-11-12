namespace VTS.Data
{
    /// <summary>Represents a COMP in VTS file for a conditional.</summary>
    public class Computation
    {
        #region Properties

        public int? Chance { get; set; }
        public string Comparison { get; set; }
        public string ControlCondition { get; set; }
        public float? ControlValue { get; set; }
        public float? CValue { get; set; }
        public string Factors { get; set; }
        public int? GlobalValue { get; set; }
        public int Id { get; set; }
        public bool? IsNot { get; set; }
        public string MethodParameters { get; set; }
        public string MethodName { get; set; }
        public int? ObjectReference { get; set; }
        public string Type { get; set; }
        public ThreePointValue UiPosition { get; set; }
        public int? Unit { get; set; }
        public string UnitGroup { get; set; }
        public string UnitList { get; set; }
        public string VehicleControl { get; set; }

        #endregion
    }
}
