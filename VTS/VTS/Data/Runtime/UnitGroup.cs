namespace VTS.Data.Runtime
{
    /// <summary>Represents all the unit groups for a team.</summary>
    public class UnitGroup : ICloneable
    {
        #region Properties

        public string Name { get; set; } // ALLIED or ENEMY
        public UnitGroupGrouping Alpha { get; set; }
        public UnitGroupGrouping Bravo { get; set; }
        public UnitGroupGrouping Charlie { get; set; }
        public UnitGroupGrouping Delta { get; set; }
        public UnitGroupGrouping Echo { get; set; }
        public UnitGroupGrouping Foxtrot { get; set; }
        public UnitGroupGrouping Golf { get; set; }
        public UnitGroupGrouping Hotel { get; set; }
        public UnitGroupGrouping India { get; set; }
        public UnitGroupGrouping Juliet { get; set; }
        public UnitGroupGrouping Kilo { get; set; }
        public UnitGroupGrouping Lima { get; set; }
        public UnitGroupGrouping Mike { get; set; }
        public UnitGroupGrouping November { get; set; }
        public UnitGroupGrouping Oscar { get; set; }
        public UnitGroupGrouping Papa { get; set; }
        public UnitGroupGrouping Quebec { get; set; }
        public UnitGroupGrouping Romeo { get; set; }
        public UnitGroupGrouping Sierra { get; set; }
        public UnitGroupGrouping Tango { get; set; }
        public UnitGroupGrouping Uniform { get; set; }
        public UnitGroupGrouping Victor { get; set; }
        public UnitGroupGrouping Whiskey { get; set; }
        public UnitGroupGrouping Xray { get; set; }
        public UnitGroupGrouping Yankee { get; set; }
        public UnitGroupGrouping Zulu { get; set; }

        public CustomScenario Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitGroup"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitGroup object.</returns>
        public UnitGroup Clone()
        {
            return new UnitGroup
            {
                Name = Name,
                Alpha = Alpha?.Clone(),
                Bravo = Bravo?.Clone(),
                Charlie = Charlie?.Clone(),
                Delta = Delta?.Clone(),
                Echo = Echo?.Clone(),
                Foxtrot = Foxtrot?.Clone(),
                Golf = Golf?.Clone(),
                Hotel = Hotel?.Clone(),
                India = India?.Clone(),
                Juliet = Juliet?.Clone(),
                Kilo = Kilo?.Clone(),
                Lima = Lima?.Clone(),
                Mike = Mike?.Clone(),
                November = November?.Clone(),
                Oscar = Oscar?.Clone(),
                Papa = Papa?.Clone(),
                Quebec = Quebec?.Clone(),
                Romeo = Romeo?.Clone(),
                Sierra = Sierra?.Clone(),
                Tango = Tango?.Clone(),
                Uniform = Uniform?.Clone(),
                Victor = Victor?.Clone(),
                Whiskey = Whiskey?.Clone(),
                Xray = Xray?.Clone(),
                Yankee = Yankee?.Clone(),
                Zulu = Zulu?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
