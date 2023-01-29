namespace VTS.Data.Runtime
{
    /// <summary>Represents a param info object.</summary>
    public class ParamInfo : ICloneable
    {
        #region Properties

        public string Name { get; set; }
        public List<ParamAttrInfo> ParamAttrInfos { get; set; } = new List<ParamAttrInfo>();
        public string Type { get; set; }
        public object Value { get; set; }

        public EventTarget Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ParamInfo"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ParamInfo object.</returns>
        public ParamInfo Clone()
        {
            ParamInfo pi = new ParamInfo
            {
                Name = Name,
                ParamAttrInfos = ParamAttrInfos.Select(x => x.Clone()).ToList(),
                Type = Type,
                Parent = Parent
            };

            /*
             * System.Boolean : value = False || True
             * System.Single : value = 1 || 1.0
             * System.String : value = '' (or any other string)
             * UnitReference : value = -1:0 (this means empty I guess) || 6 (UnitSpawner object)
             * UnitReferenceListAI : value = 0;7; (; separated list of unit ids)
             * UnitReferenceListOtherSubs : value = 157;158;179;180;183;184;260;261;312;178;152;154;159; (; separated list of unit ids)
             * ConditionalActionReference : value = 0 (id of action)
             * AirportReference : value = map:0 (base -> BaseInfo object) || unit:0 (UnitSpawner object)
             * VTSAudioReference : value = null (path on hard drive)
             * GlobalValue : value = 0 (index of global value)
             * FollowPath : value = 23 (id of path)
             * Waypoint : value = 8 (id of waypoint)
             * Teams : value = Allied || Enemy
             * FixedPoint : value = (52126.018064498901, 2258.798828125, 38374.517822265625) (ThreePointValue)
             * GroundUnitSpawn+MoveSpeeds : value = Fast_30 || Medium_20 || Slow_10
             * SmokeFlare+FlareColors : value = Blue
             */

            if (pi.Type == KeywordStrings.SystemBoolean || pi.Type == KeywordStrings.SystemSingle || pi.Type == KeywordStrings.SystemString || 
                pi.Type == KeywordStrings.Teams || pi.Type == KeywordStrings.GroundUnitSpawnPlusMoveSpeeds || pi.Type == KeywordStrings.SmokeFlarePlusFlareColors)
            {
                pi.Value = Value;
            }
            else if (pi.Type == KeywordStrings.UnitReference)
            {
                UnitSpawner unit = Value as UnitSpawner;
                
                pi.Value = unit?.Clone();
            }
            else if (pi.Type == KeywordStrings.UnitReferenceListAI || pi.Type == KeywordStrings.UnitReferenceListOtherSubs)
            {
                List<UnitSpawner> units = Value as List<UnitSpawner>;

                if (units != null)
                {
                    List<UnitSpawner> newUnits = new List<UnitSpawner>(units.Count);

                    foreach (UnitSpawner unit in units)
                    {
                        newUnits.Add(unit.Clone());
                    }

                    pi.Value = newUnits;
                }
            }
            else if (pi.Type == KeywordStrings.ConditionalActionReference)
            {
                ConditionalAction conditionalAction = Value as ConditionalAction;

                pi.Value = conditionalAction?.Clone();
            }
            else if (pi.Type == KeywordStrings.AirportReference)
            {
                if (Value is BaseInfo baseInfo)
                {
                    pi.Value = baseInfo?.Clone();
                }
                else if (Value is UnitSpawner unit)
                {
                    pi.Value = unit?.Clone();
                }
            }
            else if (pi.Type == KeywordStrings.VTSAudioReference)
            {
                FileInfo file = Value as FileInfo;

                if (file != null)
                {
                    pi.Value = new FileInfo(file.FullName);
                }
            }
            else if (pi.Type == KeywordStrings.GlobalValueParamInfoType)
            {
                GlobalValue globalValue = Value as GlobalValue;

                pi.Value = globalValue?.Clone();
            }
            else if (pi.Type == KeywordStrings.FollowPath)
            {
                Path path = Value as Path;

                pi.Value = path?.Clone();
            }
            else if (pi.Type == KeywordStrings.WaypointParamInfoType)
            {
                Waypoint waypoint = Value as Waypoint;

                pi.Value = waypoint?.Clone();
            }
            else if (pi.Type == KeywordStrings.FixedPoint)
            {
                ThreePointValue threePointValue = Value as ThreePointValue;

                pi.Value = threePointValue?.Clone();
            }

            return pi;
        }

        #endregion
    }
}
