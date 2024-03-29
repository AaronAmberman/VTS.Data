﻿namespace VTS.Data.Abstractions
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
        public string Factors { get; set; }
        public int? GlobalValue { get; set; }
        public int Id { get; set; }
        public bool? IsNot { get; set; }
        public string MethodParameters { get; set; }
        public string MethodName { get; set; }
        public int? ObjectReference { get; set; }
        public string Type { get; set; }
        public string UiPosition { get; set; }
        public int? Unit { get; set; }
        public string UnitGroup { get; set; }
        public string UnitList { get; set; }
        public string VehicleControl { get; set; }

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
                Factors = Factors,
                GlobalValue = GlobalValue,
                Id = Id,
                IsNot = IsNot,
                MethodParameters = MethodParameters,
                MethodName = MethodName,
                ObjectReference = ObjectReference,
                Type = Type,
                UiPosition = UiPosition,
                Unit = Unit,
                UnitGroup = UnitGroup,
                UnitList = UnitList,
                VehicleControl = VehicleControl
            };
        }

        #endregion
    }
}
