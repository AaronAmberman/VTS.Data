namespace VTS.Data.Runtime
{
    /// <summary>Represents a COMP in VTS file for a conditional.</summary>
    public class Computation : ICloneable
    {
        #region Properties

        public int? Chance { get; set; }
        public string Comparison { get; set; }
        public string ControlCondition { get; set; }
        public float? ControlValue { get; set; }
        public float? CValue { get; set; }
        public List<Computation> Factors { get; set; } = new List<Computation>();
        public GlobalValue GlobalValue { get; set; }
        public int Id { get; set; }
        public bool? IsNot { get; set; }
        public string MethodParameters { get; set; }
        public string MethodName { get; set; }
        public object ObjectReference { get; set; } // could be a StaticObject, ?
        public string Type { get; set; }
        public ThreePointValue UiPosition { get; set; }
        public UnitSpawner Unit { get; set; }
        public string UnitGroup { get; set; }
        public List<UnitSpawner> UnitList { get; set; } = new List<UnitSpawner>();
        public string VehicleControl { get; set; }

        public Conditional Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Computation"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Computation object.</returns>
        public Computation Clone()
        {
            return new Computation
            {
                Chance = Chance,
                Comparison = Comparison,
                ControlCondition = ControlCondition,
                ControlValue = ControlValue,
                CValue = CValue,
                Factors = Factors.Select (x => x.Clone()).ToList(),
                GlobalValue = GlobalValue.Clone(),
                Id = Id,
                IsNot = IsNot,
                MethodParameters = MethodParameters,
                MethodName = MethodName,
                ObjectReference = ObjectReference,
                Type = Type,
                UiPosition = UiPosition.Clone(),
                Unit = Unit?.Clone(),
                UnitGroup = UnitGroup,
                UnitList = UnitList.Select(x => x.Clone()).ToList(),
                VehicleControl = VehicleControl,
                Parent = Parent
            };
        }

        #endregion
    }
}
