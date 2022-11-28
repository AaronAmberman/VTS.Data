namespace VTS.Data.Abstractions
{
    /// <summary>Represents all the unit groups for a team.</summary>
    public class UnitGroup : ICloneable
    {
        #region Properties

        public string Name { get; set; }
        public string Alpha { get; set; }
        public string Bravo { get; set; }
        public string Charlie { get; set; }
        public string Delta { get; set; }
        public string Echo { get; set; }
        public string Foxtrot { get; set; }
        public string Golf { get; set; }
        public string Hotel { get; set; }
        public string India { get; set; }
        public string Juliet { get; set; }
        public string Kilo { get; set; }
        public string Lima { get; set; }
        public string Mike { get; set; }
        public string November { get; set; }
        public string Oscar { get; set; }
        public string Papa { get; set; }
        public string Quebec { get; set; }
        public string Romeo { get; set; }
        public string Sierra { get; set; }
        public string Tango { get; set; }
        public string Uniform { get; set; }
        public string Victor { get; set; }
        public string Whiskey { get; set; }
        public string Xray { get; set; }
        public string Yankee { get; set; }
        public string Zulu { get; set; }

        public List<UnitGroupSettings> UnitGroupSettings { get; set; } = new List<UnitGroupSettings>();

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
                Alpha = Alpha,
                Bravo = Bravo,
                Charlie = Charlie,
                Delta = Delta,
                Echo = Echo,
                Foxtrot = Foxtrot,
                Golf = Golf,
                Hotel = Hotel,
                India = India,
                Juliet = Juliet,
                Kilo = Kilo,
                Lima = Lima,
                Mike = Mike,
                November = November,
                Oscar = Oscar,
                Papa = Papa,
                Quebec = Quebec,
                Romeo = Romeo,
                Sierra = Sierra,
                Tango = Tango,
                Uniform = Uniform,
                Victor = Victor,
                Whiskey = Whiskey,
                Xray = Xray,
                Yankee = Yankee,
                Zulu = Zulu,
                UnitGroupSettings = UnitGroupSettings.Select(x => x.Clone()).ToList(),
            };
        }

        #endregion
    }
}
