namespace VTS.Data.Abstractions
{
    /// <summary>Represents all the unit groups for a team.</summary>
    public class UnitGroup : ICloneable
    {
        #region Properties
                                                // References to unit groups inside VTS file
        public string Name { get; set; }        // Allied       Enemy
        public string Alpha { get; set; }       // 100          200
        public string Bravo { get; set; }       // 101          201
        public string Charlie { get; set; }     // 102          202
        public string Delta { get; set; }       // 103          203
        public string Echo { get; set; }        // 104          204
        public string Foxtrot { get; set; }     // 105          205
        public string Golf { get; set; }        // 106          206
        public string Hotel { get; set; }       // 107          207
        public string India { get; set; }       // 108          208
        public string Juliet { get; set; }      // 109          209
        public string Kilo { get; set; }        // 110          210
        public string Lima { get; set; }        // 111          211
        public string Mike { get; set; }        // 112          212
        public string November { get; set; }    // 113          213
        public string Oscar { get; set; }       // 114          214
        public string Papa { get; set; }        // 115          215
        public string Quebec { get; set; }      // 116          216
        public string Romeo { get; set; }       // 117          217
        public string Sierra { get; set; }      // 118          218
        public string Tango { get; set; }       // 119          219
        public string Uniform { get; set; }     // 120          220
        public string Victor { get; set; }      // 121          221
        public string Whiskey { get; set; }     // 122          222
        public string Xray { get; set; }        // 123          223
        public string Yankee { get; set; }      // 124          224
        public string Zulu { get; set; }        // 125          225

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
