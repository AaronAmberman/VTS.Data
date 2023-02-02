using System.Collections;
using System.Diagnostics;
using VTS.Collections;
using VTS.Data.Diagnostics;

namespace VTS.Data.Runtime
{
    /// <summary>A managed wrapper for the VTS file.</summary>
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenario : ICloneable
    {
        // todo : map weapon types for all aircraft and update code where needed

        #region Fields

        private Abstractions.CustomScenario customScenario;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the path to where the EditorResources directory lives for VTOL VR.
        /// Default is C:\Program Files (x86)\Steam\steamapps\common\VTOL VR\EditorResources\.
        /// </summary>
        public static string EditorResourcesPath { get; set; } = @"C:\Program Files (x86)\Steam\steamapps\common\VTOL VR\EditorResources\";

        public string AllowedEquips { get; set; }
        public int BaseBudget { get; set; }
        public string CampaignId { get; set; }
        public int CampaignOrderIndex { get; set; }
        public string EnvironmentName { get; set; }
        public bool EquipsConfigurable { get; set; }
        public bool ForceEquips { get; set; }
        public string ForcedEquips { get; set; }
        public float FuelDrainMultiplier { get; set; }
        public string GameVersion { get; set; }
        public bool InfiniteAmmo { get; set; }
        public float InfiniteAmmoReloadDelay { get; set; }
        public bool IsTraining { get; set; }
        public string MapId { get; set; }
        public bool Multiplayer { get; set; }
        public int NormalForcedFuel { get; set; }
        public int QuickSaveLimit { get; set; }
        public string QuickSaveMode { get; set; }
        public object RefuelWaypoint { get; set; }
        public object ReturnToBaseWaypoint { get; set; }
        public string ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDescription { get; set; }
        public bool SelectableEnvironment { get; set; }
        public string Vehicle { get; set; }

        public List<BaseInfo> Bases { get; set; } = new List<BaseInfo>();
        public List<BriefingNote> BriefingNotes { get; set; } = new List<BriefingNote>();
        public List<ConditionalAction> ConditionalActions { get; set; } = new List<ConditionalAction>();
        public List<Conditional> Conditionals { get; set; } = new List<Conditional>();
        public List<Sequence> EventSequences { get; set; } = new List<Sequence>();
        public List<GlobalValue> GlobalValues { get; set; } = new List<GlobalValue>();
        public List<Objective> Objectives { get; set; } = new List<Objective>();
        public List<Objective> ObjectivesOpFor { get; set; } = new List<Objective>();
        public List<Path> Paths { get; set; } = new List<Path>();
        public List<Resource> ResourceManifest { get; set; } = new List<Resource>();
        public List<StaticObject> StaticObjects { get; set; } = new List<StaticObject>();
        public List<TimedEventGroup> TimedEventGroups { get; set; } = new List<TimedEventGroup>();
        public List<TriggerEvent> TriggerEvents { get; set; } = new List<TriggerEvent>();
        public List<UnitGroup> UnitGroups { get; set; } = new List<UnitGroup>();
        public List<UnitSpawner> Units { get; set; } = new List<UnitSpawner>();
        public PropertyedCollection<Waypoint> Waypoints { get; set; } = new PropertyedCollection<Waypoint>();

        /// <summary>Gets or sets the file reference for CustomScenario object.</summary>
        public string File { get; set; }

        /// <summary>Gets or sets whether or not there was a read or write error.</summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Gets or sets the action that the API can push warnings to so the consuming application can do as it sees fit with the warnings.
        /// Default is to just write the warnings to the Debug console.
        /// </summary>
        public Action<string> WarningAction { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        public CustomScenario()
        {
            WarningAction = WriteWarning;
        }

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        /// <param name="scenario">The custom scenario reference from the Abstraction namespace containing the data from the VTS file.</param>
        /// <exception cref="ArgumentException">Abstraction.CustomScenario.File cannot be null, empty of consist of white-space characters only.</exception>
        /// <exception cref="TypeInitializationException">Occurs if there is an issue during the conversion of the data.</exception>
        public CustomScenario(Abstractions.CustomScenario scenario)
        {
            if (string.IsNullOrWhiteSpace(scenario.File))
                throw new ArgumentException("Abstraction.CustomScenario.File cannot be null, empty of consist of white-space characters only.");

            WarningAction = WriteWarning;

            customScenario = scenario;

            Initialize();
        }

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        /// <param name="path">The path to the VTS file to read.</param>
        /// <exception cref="ArgumentException">path cannot be null, empty of consist of white-space characters only.</exception>
        /// <exception cref="TypeInitializationException">Occurs if there is an issue during the conversion of the data.</exception>
        public CustomScenario(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path cannot be null, empty of consist of white-space characters only.");

            WarningAction = WriteWarning;

            customScenario = Abstractions.CustomScenario.ReadVtsFile(path);

            Initialize();
        }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="CustomScenario"/> with all the same values as this instance.</summary>
        /// <returns>A cloned CustomScenario object.</returns>
        public CustomScenario Clone()
        {
            CustomScenario cs = new CustomScenario
            {
                AllowedEquips = AllowedEquips,
                BaseBudget = BaseBudget,
                CampaignId = CampaignId,
                CampaignOrderIndex = CampaignOrderIndex,
                EquipsConfigurable = EquipsConfigurable,
                EnvironmentName = EnvironmentName,
                ForceEquips = ForceEquips,
                ForcedEquips = ForcedEquips,
                FuelDrainMultiplier = FuelDrainMultiplier,
                GameVersion = GameVersion,
                InfiniteAmmo = InfiniteAmmo,
                InfiniteAmmoReloadDelay = InfiniteAmmoReloadDelay,
                IsTraining = IsTraining,
                MapId = MapId,
                Multiplayer = Multiplayer,
                NormalForcedFuel = NormalForcedFuel,
                QuickSaveLimit = QuickSaveLimit,
                QuickSaveMode = QuickSaveMode,
                RefuelWaypoint = RefuelWaypoint is ICloneable cloneable ? cloneable.Clone() : RefuelWaypoint, // prefer clone
                ReturnToBaseWaypoint = ReturnToBaseWaypoint is ICloneable cloneable1 ? cloneable1.Clone() : ReturnToBaseWaypoint, // prefer clone
                ScenarioId = ScenarioId,
                ScenarioName = ScenarioName,
                ScenarioDescription = ScenarioDescription,
                SelectableEnvironment = SelectableEnvironment,
                Vehicle = Vehicle,
                Bases = Bases.Select(x => x.Clone()).ToList(),
                BriefingNotes = BriefingNotes.Select(x => x.Clone()).ToList(),
                ConditionalActions = ConditionalActions.Select(x => x.Clone()).ToList(),
                Conditionals = Conditionals.Select(x => x.Clone()).ToList(),
                EventSequences = EventSequences.Select(x => x.Clone()).ToList(),
                GlobalValues = GlobalValues.Select(x => x.Clone()).ToList(),
                Objectives = Objectives.Select(x => x.Clone()).ToList(),
                ObjectivesOpFor = ObjectivesOpFor.Select(x => x.Clone()).ToList(),
                Paths = Paths.Select(x => x.Clone()).ToList(),
                ResourceManifest = ResourceManifest.Select(x => x.Clone()).ToList(),
                StaticObjects = StaticObjects.Select(x => x.Clone()).ToList(),
                TimedEventGroups = TimedEventGroups.Select(x => x.Clone()).ToList(),
                TriggerEvents = TriggerEvents.Select(x => x.Clone()).ToList(),
                UnitGroups = UnitGroups.Select(x => x.Clone()).ToList(),
                Units = Units.Select(x => x.Clone()).ToList(),
                Waypoints = new PropertyedCollection<Waypoint>(Waypoints),
                HasError = HasError,
                File = File
            };

            // update parent references on top level objects
            if (ReturnToBaseWaypoint != null)
            {
                if (ReturnToBaseWaypoint is UnitSpawner unitSpawner)
                {
                    unitSpawner.Parent = cs;
                }

                if (ReturnToBaseWaypoint is Waypoint waypoint)
                {
                    waypoint.Parent = cs;
                }
            }

            if (RefuelWaypoint != null)
            {
                if (RefuelWaypoint is UnitSpawner unitSpawner)
                {
                    unitSpawner.Parent = cs;
                }

                if (RefuelWaypoint is Waypoint waypoint)
                {
                    waypoint.Parent = cs;
                }
            }

            foreach (BaseInfo baseInfo in Bases) baseInfo.Parent = cs;
            foreach (BriefingNote briefingNote in BriefingNotes) briefingNote.Parent = cs;
            foreach (ConditionalAction conditionalAction in ConditionalActions) conditionalAction.Parent = cs;
            foreach (Conditional conditional in Conditionals) conditional.Parent = cs;
            foreach (Sequence sequence in EventSequences) sequence.Parent = cs;
            foreach (GlobalValue globalValue in GlobalValues) globalValue.Parent = cs;
            foreach (Objective objective in Objectives) objective.Parent = cs;
            foreach (Objective objective in ObjectivesOpFor) objective.Parent = cs;
            foreach (Path path in Paths) path.Parent = cs;
            foreach (Resource resource in ResourceManifest) resource.Parent = cs;
            foreach (StaticObject staticObject in StaticObjects) staticObject.Parent = cs;
            foreach (TimedEventGroup timedEventGroup in TimedEventGroups) timedEventGroup.Parent = cs;
            foreach (TriggerEvent triggerEvent in TriggerEvents) triggerEvent.Parent = cs;
            foreach (UnitGroup unitGroupGrouping in UnitGroups) unitGroupGrouping.Parent = cs;
            foreach (UnitSpawner unitSpawner in Units) unitSpawner.Parent = cs;
            foreach (Waypoint waypoint in Waypoints) waypoint.Parent = cs;

            return cs;
        }

        private void Initialize()
        {
            HasError = customScenario.HasError;
            File = customScenario.File;

            if (!customScenario.HasError)
                ReadData();
        }

        private void WriteWarning(string warning)
        {
            Debug.WriteLine(warning);
        }

        private void ReadData()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                AllowedEquips = customScenario.AllowedEquips;
                BaseBudget = customScenario.BaseBudget;
                CampaignId = customScenario.CampaignId;
                CampaignOrderIndex = customScenario.CampaignOrderIndex;
                EquipsConfigurable = customScenario.EquipsConfigurable;
                EnvironmentName = customScenario.EnvironmentName;
                ForceEquips = customScenario.ForceEquips;
                ForcedEquips = customScenario.ForcedEquips;
                FuelDrainMultiplier = customScenario.FuelDrainMultiplier;
                GameVersion = customScenario.GameVersion;
                InfiniteAmmo = customScenario.InfiniteAmmo;
                InfiniteAmmoReloadDelay = customScenario.InfiniteAmmoReloadDelay;
                IsTraining = customScenario.IsTraining;
                MapId = customScenario.MapId;
                Multiplayer = customScenario.Multiplayer;
                NormalForcedFuel = customScenario.NormalForcedFuel;
                QuickSaveLimit = customScenario.QuickSaveLimit;
                QuickSaveMode = customScenario.QuickSaveMode;
                ScenarioId = customScenario.ScenarioId;
                ScenarioName = customScenario.ScenarioName;
                ScenarioDescription = customScenario.ScenarioDescription;
                SelectableEnvironment = customScenario.SelectableEnvironment;
                Vehicle = customScenario.Vehicle;

                /*
                 * get the types that other types depend on first
                 */
                foreach (Abstractions.BaseInfo bi in customScenario.Bases)
                {
                    BaseInfo baseInfo = new BaseInfo
                    {
                        BaseTeam = bi.BaseTeam,
                        Id = bi.Id,
                        OverrideBaseName = bi.OverrideBaseName,
                        Parent = this
                    };

                    Bases.Add(baseInfo);
                }

                foreach (Abstractions.BriefingNote bn in customScenario.BriefingNotes)
                {
                    BriefingNote briefingNote = new BriefingNote
                    {
                        AudioClipPath = bn.AudioClipPath,
                        ImagePath = bn.ImagePath,
                        Text = bn.Text,
                        Parent = this
                    };

                    BriefingNotes.Add(briefingNote);
                }

                foreach (Abstractions.GlobalValue gv in customScenario.GlobalValues)
                {
                    GlobalValue globalValue = new GlobalValue
                    {
                        Description = gv.Description,
                        Index = gv.Index,
                        Name = gv.Name,
                        Value = gv.Value,
                        Parent = this
                    };

                    GlobalValues.Add(globalValue);
                }
                foreach (Abstractions.Path p in customScenario.Paths)
                {
                    Path path = new Path
                    {
                        Id = p.Id,
                        Loop = p.Loop,
                        Name = p.Name,
                        PathMode = p.PathMode,
                        Parent = this
                    };

                    string[] points = p.Points.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string point in points)
                    {
                        path.Points.Add(ReadThreePointValue(point));
                    }

                    Paths.Add(path);
                }

                foreach (Abstractions.Resource r in customScenario.ResourceManifest)
                {
                    Resource resource = new Resource
                    {
                        Index = r.Index,
                        Path = r.Path,
                        Parent = this
                    };

                    ResourceManifest.Add(resource);
                }

                foreach (Abstractions.StaticObject so in customScenario.StaticObjects)
                {
                    StaticObject staticObject = new StaticObject
                    {
                        GlobalPosition = ReadThreePointValue(so.GlobalPosition),
                        Id = so.Id,
                        PrefabId = so.PrefabId,
                        Rotation = ReadThreePointValue(so.Rotation),
                        Parent = this
                    };

                    StaticObjects.Add(staticObject);
                }

                foreach (Abstractions.Waypoint w in customScenario.Waypoints)
                {
                    Waypoint waypoint = new Waypoint
                    {
                        GlobalPoint = ReadThreePointValue(w.GlobalPoint),
                        Id = w.Id,
                        Name = w.Name,
                        Parent = this
                    };

                    Waypoints.Add(waypoint);
                }

                for (int i = 0; i < customScenario.Waypoints.GetPropertyCount(); i++)
                {
                    DictionaryEntry property = customScenario.Waypoints.GetProperty(i);

                    Waypoints.AddProperty(property.Key, property.Value);
                }

                foreach (Abstractions.UnitSpawner us in customScenario.Units)
                {
                    UnitSpawner unit = new UnitSpawner
                    {
                        EditorPlacementMode = us.EditorPlacementMode,
                        GlobalPosition = ReadThreePointValue(us.GlobalPosition),
                        LastValidPlacement = ReadThreePointValue(us.LastValidPlacement),
                        Rotation = ReadThreePointValue(us.Rotation),
                        SpawnChance = us.SpawnChance,
                        SpawnFlags = us.SpawnFlags,
                        UnitId = us.UnitId,
                        UnitInstanceId = us.UnitInstanceId,
                        UnitName = us.UnitName,
                        Parent = this
                    };

                    UnitFields unitFields = new UnitFields
                    {
                        AllowReload = us.UnitFields.AllowReload,
                        AutoRefuel = us.UnitFields.AutoRefuel,
                        AutoReturnToBase = us.UnitFields.AutoReturnToBase,
                        AwacsVoiceProfile = us.UnitFields.AwacsVoiceProfile,
                        Behavior = us.UnitFields.Behavior,
                        CombatTarget = us.UnitFields.CombatTarget,
                        CommsEnabled = us.UnitFields.CommsEnabled,
                        DefaultBehavior = us.UnitFields.DefaultBehavior,
                        DefaultNavSpeed = us.UnitFields.DefaultNavSpeed,
                        DefaultOrbitPoint = us.UnitFields.DefaultOrbitPoint,
                        DefaultPath = us.UnitFields.DefaultPath,
                        DefaultRadarEnabled = us.UnitFields.DefaultRadarEnabled,
                        DefaultShotsPerSalvo = us.UnitFields.DefaultShotsPerSalvo,
                        DefaultWaypoint = us.UnitFields.DefaultWaypoint,
                        DetectionMode = us.UnitFields.DetectionMode,
                        EngageEnemies = us.UnitFields.EngageEnemies,
                        Fuel = us.UnitFields.Fuel,
                        HullNumber = us.UnitFields.HullNumber,
                        InitialSpeed = us.UnitFields.InitialSpeed,
                        Invincible = us.UnitFields.Invincible,
                        MoveSpeed = us.UnitFields.MoveSpeed,
                        OrbitAltitude = us.UnitFields.OrbitAltitude,
                        ParkedStartMode = us.UnitFields.ParkedStartMode,
                        PlayerCommandsMode = us.UnitFields.PlayerCommandsMode,
                        RadarUnits = us.UnitFields.RadarUnits,
                        ReceiveFriendlyDamage = us.UnitFields.ReceiveFriendlyDamage,
                        ReloadTime = us.UnitFields.ReloadTime,
                        Respawnable = us.UnitFields.Respawnable,
                        RippleRate = us.UnitFields.RippleRate,
                        SpawnOnStart = us.UnitFields.SpawnOnStart,
                        StartMode = us.UnitFields.StartMode,
                        StopToEngage = us.UnitFields.StopToEngage,
                        UnitGroup = us.UnitFields.UnitGroup,
                        VoiceProfile = us.UnitFields.VoiceProfile,
                        Parent = unit
                    };

                    // if the property is empty then let it continue to be empty
                    unitFields.Equips = us.UnitFields.Equips;

                    if (!string.IsNullOrWhiteSpace(us.UnitFields.Waypoint) && us.UnitFields.Waypoint != KeywordStrings.Null)
                    {
                        int id = Convert.ToInt32(us.UnitFields.Waypoint);

                        Waypoint match = Waypoints.FirstOrDefault(w => w.Id == id);

                        if (match == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: waypoint {id} referenced on unit [unitInstanceID:{us.UnitInstanceId}] could not be found by id. No matching waypoint in the Waypoints collection.");
                        }
                        else
                        {
                            unitFields.Waypoint = match;
                        }
                    }

                    unit.UnitFields = unitFields;

                    Units.Add(unit);
                }

                // loop through the units again so we can set the carrier spawn references and the RTB destination (because it might be another unit)
                // (run a second loop to ensure all the units can properly be referenced because unit order is not guaranteed)
                for (int i = 0; i < Units.Count; i++)
                {
                    Abstractions.UnitSpawner u = customScenario.Units[i];
                    UnitSpawner unit = Units[i];

                    if (!string.IsNullOrWhiteSpace(u.UnitFields.CarrierSpawns))
                    {
                        string[] cs = u.UnitFields.CarrierSpawns.Split(';', StringSplitOptions.RemoveEmptyEntries);

                        foreach (string str in cs)
                        {
                            string[] indexUnit = str.Split(':');
                            int index = Convert.ToInt32(indexUnit[0]);
                            int unitId = Convert.ToInt32(indexUnit[1]);

                            if (unitId == -1) continue; // move on

                            // there should be a match so do not use FirstOrDefault, if there is not
                            // match then there has been some kind of error processing the data
                            UnitSpawner carrierSpawn = Units.FirstOrDefault(theUnit => theUnit.UnitInstanceId == unitId);

                            if (carrierSpawn == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the carrier unit {u.UnitInstanceId} referenced unit {unitId} and that unit could not be found in the collection of Units.");
                            }
                            else
                            {
                                unit.UnitFields.CarrierSpawns.Add(new Tuple<int, UnitSpawner>(index, carrierSpawn));
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(u.UnitFields.ReturnToBaseDestination))
                    {
                        if (u.UnitFields.ReturnToBaseDestination.StartsWith(KeywordStrings.MapWaypoint)) // BaseInfo object
                        {
                            string[] values = u.UnitFields.ReturnToBaseDestination.Split(':');

                            // base references seem to be index based not id based
                            int index = Convert.ToInt32(values[1]);

                            if (index > Bases.Count)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the RTB destination {index} on unit {u.UnitInstanceId} could not be found in the list of Bases as the index was greater than the number of bases.");
                            }
                            else
                            {
                                unit.UnitFields.ReturnToBaseDestination = Bases[index];
                            }
                        }
                        else if (u.UnitFields.ReturnToBaseDestination.StartsWith(KeywordStrings.UnitWaypoint)) // UnitSpawner object
                        {
                            string[] values = u.UnitFields.ReturnToBaseDestination.Split(':');
                            int id = Convert.ToInt32(values[1]);

                            UnitSpawner rtb = Units.FirstOrDefault(theUnit => theUnit.UnitInstanceId == id);

                            if (rtb == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the RTB destination {id} on unit {u.UnitInstanceId} could not be found in the list of Units.");
                            }
                            else
                            {
                                unit.UnitFields.ReturnToBaseDestination = rtb;
                            }
                        }
                    }
                }

                // see if we need to set the ReturnToBaseWaypoint
                if (!string.IsNullOrWhiteSpace(customScenario.ReturnToBaseWaypointId))
                {
                    string[] data = customScenario.ReturnToBaseWaypointId.Split(':');

                    if (data.Length > 0)
                    {
                        int id = Convert.ToInt32(data[1]);

                        if (data[0] == KeywordStrings.Unit)
                        {
                            UnitSpawner match = Units.FirstOrDefault(w => w.UnitInstanceId == id);

                            if (match == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the unit referenced in the rtbWptID {customScenario.ReturnToBaseWaypointId} could not be found in the list of Units.");
                            }
                            else
                            {
                                ReturnToBaseWaypoint = match;
                            }
                        }
                        else if (data[0] == KeywordStrings.Wpt)
                        {
                            Waypoint match = Waypoints.FirstOrDefault(w => w.Id == id);

                            if (match == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the waypoint referenced in the rtbWptID {customScenario.ReturnToBaseWaypointId} could not be found in the list of Waypoints.");
                            }
                            else
                            {
                                ReturnToBaseWaypoint = match;
                            }
                        }
                    }
                }

                // see if we need to set the RefuelWaypoint
                if (!string.IsNullOrWhiteSpace(customScenario.RefuelWaypointId))
                {
                    string[] data = customScenario.RefuelWaypointId.Split(':');

                    if (data.Length > 0)
                    {
                        int id = Convert.ToInt32(data[1]);

                        if (data[0] == KeywordStrings.Unit)
                        {
                            UnitSpawner match = Units.FirstOrDefault(w => w.UnitInstanceId == id);

                            if (match == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the unit referenced in the refuelWptID {customScenario.RefuelWaypointId} could not be found in the list of Units.");
                            }
                            else
                            {
                                RefuelWaypoint = match;
                            }

                        }
                        else if (data[0] == KeywordStrings.Wpt)
                        {
                            Waypoint match = Waypoints.FirstOrDefault(w => w.Id == id);

                            if (match == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the waypoint referenced in the refuelWptID {customScenario.ReturnToBaseWaypointId} could not be found in the list of Waypoints.");
                            }
                            else
                            {
                                RefuelWaypoint = match;
                            }
                        }
                    }
                }

                foreach (Abstractions.UnitGroup ug in customScenario.UnitGroups)
                {
                    UnitGroup unitGroup = new UnitGroup
                    {
                        Name = ug.Name, // ALLIED or ENEMY
                        Parent = this
                    };

                    unitGroup.Alpha = ReadUnitGroup(ug, KeywordStrings.Alpha, ug.Alpha);
                    unitGroup.Bravo = ReadUnitGroup(ug, KeywordStrings.Bravo, ug.Bravo);
                    unitGroup.Charlie = ReadUnitGroup(ug, KeywordStrings.Charlie, ug.Charlie);
                    unitGroup.Delta = ReadUnitGroup(ug, KeywordStrings.Delta, ug.Delta);
                    unitGroup.Echo = ReadUnitGroup(ug, KeywordStrings.Echo, ug.Echo);
                    unitGroup.Foxtrot = ReadUnitGroup(ug, KeywordStrings.Foxtrot, ug.Foxtrot);
                    unitGroup.Golf = ReadUnitGroup(ug, KeywordStrings.Golf, ug.Golf);
                    unitGroup.Hotel = ReadUnitGroup(ug, KeywordStrings.Hotel, ug.Hotel);
                    unitGroup.India = ReadUnitGroup(ug, KeywordStrings.India, ug.India);
                    unitGroup.Juliet = ReadUnitGroup(ug, KeywordStrings.Juliet, ug.Juliet);
                    unitGroup.Kilo = ReadUnitGroup(ug, KeywordStrings.Kilo, ug.Kilo);
                    unitGroup.Lima = ReadUnitGroup(ug, KeywordStrings.Lima, ug.Lima);
                    unitGroup.Mike = ReadUnitGroup(ug, KeywordStrings.Mike, ug.Mike);
                    unitGroup.November = ReadUnitGroup(ug, KeywordStrings.November, ug.November);
                    unitGroup.Oscar = ReadUnitGroup(ug, KeywordStrings.Oscar, ug.Oscar);
                    unitGroup.Papa = ReadUnitGroup(ug, KeywordStrings.Papa, ug.Papa);
                    unitGroup.Quebec = ReadUnitGroup(ug, KeywordStrings.Quebec, ug.Quebec);
                    unitGroup.Romeo = ReadUnitGroup(ug, KeywordStrings.Romeo, ug.Romeo);
                    unitGroup.Sierra = ReadUnitGroup(ug, KeywordStrings.Sierra, ug.Sierra);
                    unitGroup.Tango = ReadUnitGroup(ug, KeywordStrings.Tango, ug.Tango);
                    unitGroup.Uniform = ReadUnitGroup(ug, KeywordStrings.Uniform, ug.Uniform);
                    unitGroup.Victor = ReadUnitGroup(ug, KeywordStrings.Victor, ug.Victor);
                    unitGroup.Whiskey = ReadUnitGroup(ug, KeywordStrings.Whiskey, ug.Whiskey);
                    unitGroup.Xray = ReadUnitGroup(ug, KeywordStrings.Xray, ug.Xray);
                    unitGroup.Yankee = ReadUnitGroup(ug, KeywordStrings.Yankee, ug.Yankee);
                    unitGroup.Zulu = ReadUnitGroup(ug, KeywordStrings.Zulu, ug.Zulu);

                    UnitGroups.Add(unitGroup);
                }

                /*
                 * get types that depend on other types
                 */
                foreach (Abstractions.Conditional c in customScenario.Conditionals)
                {
                    Conditionals.Add(ReadConditional(c, customScenario));
                }

                foreach (Abstractions.ConditionalAction ca in customScenario.ConditionalActions)
                {
                    ConditionalAction conditionalAction = new ConditionalAction
                    {
                        Id = ca.Id,
                        Name = ca.Name,
                        Parent = this
                    };

                    Block baseBlock = new Block
                    {
                        BlockId = ca.BaseBlock.BlockId,
                        BlockName = ca.BaseBlock.BlockName,
                        Parent = conditionalAction
                    };

                    baseBlock.Actions = ReadEventInfo(ca.BaseBlock.Actions, baseBlock, false, false);
                    baseBlock.Conditional = ReadConditional(ca.BaseBlock.Conditional, baseBlock);
                    baseBlock.ElseActions = ReadEventInfo(ca.BaseBlock.ElseActions, baseBlock, false, false);

                    foreach (Abstractions.Block eib in ca.BaseBlock.ElseIfBlocks)
                    {
                        Block elseIfBlock = new Block
                        {
                            BlockId = eib.BlockId,
                            BlockName = eib.BlockName,
                            Parent = baseBlock
                        };

                        elseIfBlock.Actions = ReadEventInfo(eib.Actions, elseIfBlock, false, false);
                        elseIfBlock.Conditional = ReadConditional(eib.Conditional, elseIfBlock);
                        elseIfBlock.ElseActions = ReadEventInfo(eib.ElseActions, elseIfBlock, false, false);

                        baseBlock.ElseIfBlocks.Add(elseIfBlock);
                    }

                    conditionalAction.BaseBlock = baseBlock;

                    ConditionalActions.Add(conditionalAction);
                }

                foreach (Abstractions.TriggerEvent te in customScenario.TriggerEvents)
                {
                    TriggerEvent triggerEvent = new TriggerEvent
                    {
                        Enabled = te.Enabled,
                        EventName = te.EventName,
                        Id = te.Id,
                        ProxyMode = te.ProxyMode,
                        Radius = te.Radius,
                        SphericalRadius = te.SphericalRadius,
                        TriggerMode = te.TriggerMode,
                        TriggerType = te.TriggerType,
                        Parent = this
                    };

                    triggerEvent.EventInfo = ReadEventInfo(te.EventInfo, triggerEvent, false, true);

                    if (te.Conditional.HasValue)
                    {
                        Conditional conditional = Conditionals.FirstOrDefault(x => x.Id == te.Conditional.Value);

                        if (conditional == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the trigger event {te.Id} references conditional {te.Conditional.Value} and that conditional could not be found in the list of Conditionals.");
                        }
                        else
                        {
                            triggerEvent.Conditional = conditional;
                        }
                    }

                    if (te.Waypoint.HasValue)
                    {
                        Waypoint waypoint = Waypoints.FirstOrDefault(x => x.Id == te.Waypoint.Value);

                        if (waypoint == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the trigger event {te.Id} references waypoint {te.Waypoint.Value} and that waypoint could not be found in the list of Waypoints.");
                        }
                        else
                        {
                            triggerEvent.Waypoint = waypoint;
                        }
                    }

                    TriggerEvents.Add(triggerEvent);
                }

                // loop through a second time in case trigger events reference other trigger events
                for (int i = 0; i < TriggerEvents.Count; i++)
                {
                    TriggerEvent triggerEvent = TriggerEvents[i];
                    Abstractions.TriggerEvent te = customScenario.TriggerEvents[i];

                    for (int j = 0; j < triggerEvent.EventInfo.EventTargets.Count; j++)
                    {
                        EventTarget eventTarget = triggerEvent.EventInfo.EventTargets[j];
                        Abstractions.EventTarget et = te.EventInfo.EventTargets[j];

                        if (eventTarget.TargetType == KeywordStrings.TriggerEventsProperty)
                        {
                            TriggerEvent trigEve = TriggerEvents.FirstOrDefault(te => te.Id == et.TargetId);

                            if (trigEve == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references trigger event {et.TargetId} and that trigger event could not be found in the list of TriggerEvents.");
                            }
                            else
                            {
                                eventTarget.Target = trigEve;
                            }
                        }
                    }
                }

                // loop through conditional actions again in case they reference triggers or other conditional actions
                for (int i = 0; i < ConditionalActions.Count; i++)
                {
                    ConditionalAction conditionalAction = ConditionalActions[i];
                    Abstractions.ConditionalAction ca = customScenario.ConditionalActions[i];

                    for (int j = 0; j < conditionalAction.BaseBlock.Actions.EventTargets.Count; j++)
                    {
                        EventTarget eventTarget = conditionalAction.BaseBlock.Actions.EventTargets[j];
                        Abstractions.EventTarget et = ca.BaseBlock.Actions.EventTargets[j];

                        if (eventTarget.TargetType == KeywordStrings.TriggerEventsProperty)
                        {
                            TriggerEvent trigEve = TriggerEvents.FirstOrDefault(te => te.Id == et.TargetId);

                            if (trigEve == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references trigger event {et.TargetId} and that trigger event could not be found in the list of TriggerEvents.");
                            }
                            else
                            {
                                eventTarget.Target = trigEve;
                            }
                        }

                        for (int k = 0; k < eventTarget.ParamInfos.Count; k++)
                        {
                            ParamInfo paramInfo = eventTarget.ParamInfos[k];
                            Abstractions.ParamInfo pi = et.ParamInfos[k];

                            if (paramInfo.Type == KeywordStrings.ConditionalActionReference)
                            {
                                string val = pi.Value;

                                if (string.IsNullOrEmpty(val))
                                {
                                    continue;
                                }

                                int id = Convert.ToInt32(val);

                                ConditionalAction reference = ConditionalActions.FirstOrDefault(x => x.Id == id);

                                if (reference != null)
                                {
                                    paramInfo.Value = reference;
                                }
                            }
                        }
                    }

                    for (int j = 0; j < conditionalAction.BaseBlock.ElseActions.EventTargets.Count; j++)
                    {
                        EventTarget eventTarget = conditionalAction.BaseBlock.ElseActions.EventTargets[j];
                        Abstractions.EventTarget et = ca.BaseBlock.ElseActions.EventTargets[j];

                        if (eventTarget.TargetType == KeywordStrings.TriggerEventsProperty)
                        {
                            TriggerEvent trigEve = TriggerEvents.FirstOrDefault(te => te.Id == et.TargetId);

                            if (trigEve == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references trigger event {et.TargetId} and that trigger event could not be found in the list of TriggerEvents.");
                            }
                            else
                            {
                                eventTarget.Target = trigEve;
                            }
                        }

                        for (int k = 0; k < eventTarget.ParamInfos.Count; k++)
                        {
                            ParamInfo paramInfo = eventTarget.ParamInfos[k];
                            Abstractions.ParamInfo pi = et.ParamInfos[k];

                            if (paramInfo.Type == KeywordStrings.ConditionalActionReference)
                            {
                                string val = pi.Value;

                                if (string.IsNullOrEmpty(val))
                                {
                                    continue;
                                }

                                int id = Convert.ToInt32(val);

                                ConditionalAction reference = ConditionalActions.FirstOrDefault(x => x.Id == id);

                                if (reference != null)
                                {
                                    paramInfo.Value = reference;
                                }
                            }
                        }
                    }
                }

                foreach (Abstractions.Sequence s in customScenario.EventSequences)
                {
                    Sequence sequence = new Sequence
                    {
                        Id = s.Id,
                        SequenceName = s.SequenceName,
                        StartImmediately = s.StartImmediately,
                        WhileLoop = s.WhileLoop,
                        Parent = this
                    };

                    foreach (Abstractions.Event e in s.Events)
                    {
                        Event @event = new Event
                        {
                            Delay = e.Delay,
                            NodeName = e.NodeName,
                            Parent = sequence
                        };

                        @event.EventInfo = ReadEventInfo(e.EventInfo, sequence, true, true);

                        if (e.Conditional.HasValue)
                        {
                            Conditional conditional = Conditionals.FirstOrDefault(x => x.Id == e.Conditional);

                            if (conditional == null)
                            {
                                int cond = e.Conditional.HasValue ? e.Conditional.Value : -1;

                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event sequence {s.Id} references conditional [{cond}] and that conditional could not be found in the list of Conditionals.");
                            }
                            else
                            {
                                @event.Conditional = conditional;
                            }
                        }

                        if (e.ExitConditional.HasValue)
                        {
                            Conditional conditional = Conditionals.FirstOrDefault(x => x.Id == e.ExitConditional.Value);

                            if (conditional == null)
                            {
                                int cond = e.ExitConditional.HasValue ? e.ExitConditional.Value : -1;

                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event sequence {s.Id} references exit conditional [{cond}] and that exit conditional could not be found in the list of Conditionals.");
                            }
                            else
                            {
                                @event.ExitConditional = conditional;
                            }
                        }

                        sequence.Events.Add(@event);
                    }

                    EventSequences.Add(sequence);
                }

                foreach (Abstractions.Objective o in customScenario.Objectives)
                {
                    Objectives.Add(ReadObjective(o));
                }

                // loop through a second time to assign the prereq property because it is a list of other Objectives
                // (loop a second time because I am not sure if the order of Objectives is guaranteed)
                for (int i = 0; i < Objectives.Count; i++)
                {
                    SetObjectivePreReqs(i, false);
                }

                foreach (Abstractions.Objective o in customScenario.ObjectivesOpFor)
                {
                    ObjectivesOpFor.Add(ReadObjective(o));
                }

                // loop through a second time to assign the prereq property because it is a list of other Objectives
                // (loop a second time because I am not sure if the order of Objectives is guaranteed)
                for (int i = 0; i < ObjectivesOpFor.Count; i++)
                {
                    SetObjectivePreReqs(i, true);
                }

                foreach (Abstractions.TimedEventGroup teg in customScenario.TimedEventGroups)
                {
                    TimedEventGroup timedEventGroup = new TimedEventGroup
                    {
                        BeginImmediately = teg.BeginImmediately,
                        GroupId = teg.GroupId,
                        GroupName = teg.GroupName,
                        InitialDelay = teg.InitialDelay,
                        Parent = this
                    };

                    foreach (Abstractions.TimedEventInfo tei in teg.TimedEventInfos)
                    {
                        TimedEventInfo timedEventInfo = new TimedEventInfo
                        {
                            EventName = tei.EventName,
                            Time = tei.Time,
                            Parent = timedEventGroup
                        };

                        foreach (Abstractions.EventTarget et in tei.EventTargets)
                        {
                            timedEventInfo.EventTargets.Add(ReadEventTarget(et, timedEventInfo, true, true));
                        }

                        timedEventGroup.TimedEventInfos.Add(timedEventInfo);
                    }

                    TimedEventGroups.Add(timedEventGroup);
                }

                sw.Stop();

                if (DiagnosticOptions.OutputCustomScenarioConversionTime)
                    Debug.WriteLine($"VTS.Data.Abstractions.CustomScenario converted to VTS.Data.Runtime.CustomScenario:{sw.Elapsed}");
            }
            catch (Exception ex)
            {
                throw new TypeInitializationException("VTS.Data.Runtime.CustomScenario", ex);
            }
        }

        private UnitGroupGrouping ReadUnitGroup(Abstractions.UnitGroup ug, string group, string groupUnits)
        {
            if (string.IsNullOrWhiteSpace(groupUnits)) return null;

            UnitGroupGrouping groupGrouping = new UnitGroupGrouping
            {
                Name = group // Alpha, Bravo, Charlie, etc.
            };

            Abstractions.UnitGroupSettings ugs = ug.UnitGroupSettings.FirstOrDefault(ugs => ugs.Name.StartsWith(group));

            if (ugs != null)
            {
                groupGrouping.Settings = new UnitGroupSettings
                {
                    Name = ugs.Name, // Alpha_SETTINGS, Bravo_SETTINGS, etc.
                    SyncAltSpawns = ugs.SyncAltSpawns,
                    Parent = groupGrouping
                };
            }

            if (!string.IsNullOrWhiteSpace(groupUnits))
            {
                string[] unitsIds = groupUnits.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string unitId in unitsIds)
                {
                    int id = Convert.ToInt32(unitId);

                    UnitSpawner unit = Units.FirstOrDefault(u => u.UnitInstanceId == id);

                    if (unit == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the unit group {group} references unit {unitId} and that unit could not be found in the list of Units.");

                        continue; // move on as no match was found
                    }

                    /*
                     * Note: there seems to be an issue with VTOL VR for unit groups. Sometimes units are repeated
                     * within the same group and will often times appear in multiple groups incorrectly. Units can
                     * only be assigned to one group. Validate both of these and throw warning out to Debug console.
                     * Also, put data in the correct location based on UnitSpawner.UnitFields.UnitGroup data.
                     */

                    // check if the unit even belongs with this group (check UnitSpawner.UnitFields.UnitGroup)
                    if (unit.UnitFields.UnitGroup != null && !string.IsNullOrWhiteSpace(unit.UnitFields.UnitGroup) && unit.UnitFields.UnitGroup != KeywordStrings.Null)
                    {
                        string[] groupData = unit.UnitFields.UnitGroup.Split(':');

                        // should match "enemy" or "allied"
                        if (groupData[0].Equals(ug.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            if (groupData[1] != group)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario UnitGroup Data Warning: the unit {unitId} is not assigned to the correct group. Unit is supposed to be included in {groupData[1]} but it is listed in {group} incorrectly. Skipping unit.");

                                continue;
                            }
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario UnitGroup Data Warning: the unit {unitId} is not assigned to the correct larger group of groups. Current group: {ug.Name}, listed group for unit: {groupData[0]}. This means an Allied unit appeared in a Enemy group or Enemy unit appeared in an Allied group. Skipping unit.");

                            continue;
                        }
                    }

                    // check duplicity, should be ok to check the instance because all instances come from the Units collection
                    if (groupGrouping.Units.Contains(unit))
                        WriteWarning($"VTS.Data.Runtime.CustomScenario UnitGroup Data Warning: unit {unit.UnitName} (unitInstanceID = {unit.UnitInstanceId}) is already a part of this group. Duplicate ID entry for the same unit within the same group ({group}). Skipping duplicate.");
                    else
                        groupGrouping.Units.Add(unit); // if not a duplicate and we are in the correct group, assign unit
                }
            }

            return groupGrouping;
        }

        private EventInfo ReadEventInfo(Abstractions.EventInfo ei, object parent, bool processTriggerEvents, bool processConditionaActionReference)
        {
            EventInfo eventInfo = new EventInfo
            {
                EventName = ei.EventName,
                Parent = parent
            };

            foreach (Abstractions.EventTarget et in ei.EventTargets)
            {
                eventInfo.EventTargets.Add(ReadEventTarget(et, eventInfo, processTriggerEvents, processConditionaActionReference));
            }

            return eventInfo;
        }

        private EventTarget ReadEventTarget(Abstractions.EventTarget et, object parent, bool processTriggerEvents, bool processConditionaActionReference)
        {
            EventTarget eventTarget = new EventTarget
            {
                EventName = et.EventName,
                MethodName = et.MethodName,
                TargetType = et.TargetType,
                Parent = parent
            };

            if (et.TargetType == KeywordStrings.EventTargetUnit)
            {
                UnitSpawner unit = Units.FirstOrDefault(u => u.UnitInstanceId == et.TargetId);

                if (unit == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references unit {et.TargetId} and that unit could not be found in the list of Units.");
                }
                else
                {
                    eventTarget.Target = unit;
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetEventSequences)
            {
                Sequence sequence = EventSequences.FirstOrDefault(es => es.Id == et.TargetId);

                if (sequence == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references event sequence {et.TargetId} and that event sequence could not be found in the list of EventSequences.");
                }
                else
                {
                    eventTarget.Target = sequence;
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetTriggerEvents && processTriggerEvents)
            {
                TriggerEvent triggerEvent = TriggerEvents.FirstOrDefault(te => te.Id == et.TargetId);

                if (triggerEvent == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references trigger event {et.TargetId} and that trigger event could not be found in the list of TriggerEvents.");
                }
                else
                {
                    eventTarget.Target = triggerEvent;
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetStaticObject)
            {
                StaticObject staticObject = StaticObjects.FirstOrDefault(so => so.Id == et.TargetId);

                if (staticObject == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the event target {et.EventName} references static object {et.TargetId} and that static object could not be found in the list of StaticObjects.");
                }
                else
                {
                    eventTarget.Target = staticObject;
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetUnitGroup)
                eventTarget.Target = et.TargetId; // just box the int that represents the group because I am not sure how these map
            else if (et.TargetType == KeywordStrings.System)
                eventTarget.Target = et.TargetId; // just box up the 0 as I don't believe it is used for system

            foreach (Abstractions.ParamInfo pi in et.ParamInfos)
            {
                ParamInfo paramInfo = new ParamInfo
                {
                    Name = pi.Name,
                    Type = pi.Type,
                    Parent = eventTarget
                };

                /*
                 * System.Boolean : value = False || True
                 * System.Single : value = 1 || 1.0
                 * UnitReference : value = -1:0 (this means empty I guess) || 6 (UnitSpawner object)
                 * UnitReferenceListAI : value = 0;7; (; separated list of unit ids)
                 * UnitReferenceListOtherSubs : value = 157;158;179;180;183;184;260;261;312;178;152;154;159; (; separated list of unit ids)
                 * ConditionalActionReference : value = 0 (id of action)
                 * AirportReference : value = map:0 (BaseInfo object) || unit:0 (UnitSpawner object)
                 * VTSAudioReference : value = null (path on hard drive)
                 * GlobalValue : value = 0 (index of global value)
                 * FollowPath : value = 23 (id of path)
                 * Waypoint : value = 8 (id of waypoint)
                 * FixedPoint : value = (52126.018064498901, 2258.798828125, 38374.517822265625) (ThreePointValue)
                 * Teams : value = Allied || Enemy
                 * System.String : value = '' (or any other string)
                 * GroundUnitSpawn+MoveSpeeds : value = Fast_30 || Medium_20 || Slow_10
                 * SmokeFlare+FlareColors : value = Blue
                 */

                if (string.IsNullOrWhiteSpace(pi.Value)) paramInfo.Value = null;
                else if (pi.Value == KeywordStrings.Null) paramInfo.Value = null;
                else
                {
                    if (pi.Type == KeywordStrings.SystemBoolean)
                    {
                        paramInfo.Value = Convert.ToBoolean(pi.Value);
                    }
                    else if (pi.Type == KeywordStrings.SystemSingle)
                    {
                        paramInfo.Value = Convert.ToSingle(pi.Value);
                    }
                    else if (pi.Type == KeywordStrings.UnitReference)
                    {
                        if (pi.Value.StartsWith("-1", StringComparison.OrdinalIgnoreCase))
                        {
                            paramInfo.Value = null;
                        }
                        else
                        {
                            int id  = Convert.ToInt32(pi.Value);

                            UnitSpawner match = Units.FirstOrDefault(unit => unit.UnitInstanceId == id);

                            if (match != null)
                            {
                                paramInfo.Value = match;
                            }
                            else
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a unit reference [{pi.Value}] that could not be found.");
                            }
                        }
                    }
                    else if (pi.Type == KeywordStrings.UnitReferenceListAI || pi.Type == KeywordStrings.UnitReferenceListOtherSubs)
                    {
                        string[] units = pi.Value.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        List<UnitSpawner> paramInfoUnits = new List<UnitSpawner>();

                        foreach (string unit in units)
                        {
                            int id = Convert.ToInt32(unit);

                            UnitSpawner match = Units.FirstOrDefault(unit => unit.UnitInstanceId == id);

                            if (match != null)
                            {
                                paramInfoUnits.Add(match);
                            }
                            else
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a unit reference [{pi.Value}] in its list of units that could not be found.");
                            }
                        }

                        paramInfo.Value = paramInfoUnits;
                    }
                    else if (pi.Type == KeywordStrings.ConditionalActionReference && processConditionaActionReference)
                    {
                        int id = Convert.ToInt32(pi.Value);

                        ConditionalAction ca = ConditionalActions.FirstOrDefault(action => action.Id == id);

                        if (ca != null)
                        {
                            paramInfo.Value = ca;
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a conditional action reference [{pi.Value}] that could not be found.");
                        }
                    }
                    else if (pi.Type == KeywordStrings.AirportReference)
                    {
                        if (pi.Value.StartsWith(KeywordStrings.MapWaypoint)) // BaseInfo object
                        {
                            string[] values = pi.Value.Split(':');

                            // base references seem to be index based not id based
                            int index = Convert.ToInt32(values[1]);

                            if (index > Bases.Count)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a airport reference (base) [{pi.Value}] that could not be found.");
                            }
                            else
                            {
                                paramInfo.Value = Bases[index];
                            }
                        }
                        else if (pi.Value.StartsWith(KeywordStrings.UnitWaypoint)) // UnitSpawner object
                        {
                            string[] values = pi.Value.Split(':');
                            int id = Convert.ToInt32(values[1]);

                            UnitSpawner rtb = Units.FirstOrDefault(theUnit => theUnit.UnitInstanceId == id);

                            if (rtb == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a airport reference (unit) [{pi.Value}] that could not be found.");
                            }
                            else
                            {
                                paramInfo.Value = rtb;
                            }
                        }
                    }
                    else if (pi.Type == KeywordStrings.VTSAudioReference)
                    {
                        try
                        {
                            string path = System.IO.Path.Combine(EditorResourcesPath, pi.Value);

                            if (System.IO.File.Exists(path))
                            {
                                paramInfo.Value = new FileInfo(path);
                            }
                            else
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching File Data Warning: The VTSAudioReference {pi.Value} could not be found. Please be sure to set the EditorResourcesPath if VTOL VR is installed some where other than Program Files (x86).");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching File Data Warning: The VTSAudioReference {pi.Value} could not be found. Please be sure to set the EditorResourcesPath if VTOL VR is installed some where other than Program Files (x86).{Environment.NewLine}{ex.Message}");
                        }
                    }
                    else if (pi.Type == KeywordStrings.GlobalValueParamInfoType)
                    {
                        int index = Convert.ToInt32(pi.Value);

                        GlobalValue globalValue = GlobalValues[index];

                        if (globalValue == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a global value reference [{pi.Value}] that could not be found.");
                        }
                        else
                        {
                            paramInfo.Value = globalValue;
                        }
                    }
                    else if (pi.Type == KeywordStrings.FollowPath)
                    {
                        int id = Convert.ToInt32(pi.Value);

                        Path path = Paths.FirstOrDefault(p => p.Id == id);

                        if (path == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a path reference [{pi.Value}] that could not be found.");
                        }
                        else
                        {
                            paramInfo.Value = path;
                        }
                    }
                    else if (pi.Type == KeywordStrings.WaypointParamInfoType)
                    {
                        int id = Convert.ToInt32(pi.Value);

                        Waypoint waypoint = Waypoints.FirstOrDefault(wp => wp.Id == id);

                        if (waypoint == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Index Data Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a waypoint reference [{pi.Value}] that could not be found.");
                        }
                        else
                        {
                            paramInfo.Value = waypoint;
                        }
                    }
                    else if (pi.Type == KeywordStrings.FixedPoint)
                    {
                        paramInfo.Value = ReadThreePointValue(pi.Value);
                    }
                    else if (pi.Type == KeywordStrings.GroundUnitSpawnPlusMoveSpeeds || pi.Type == KeywordStrings.SmokeFlarePlusFlareColors || 
                             pi.Type == KeywordStrings.Teams || pi.Type == KeywordStrings.SystemString)
                    {
                        paramInfo.Value = pi.Value;
                    }
                }

                foreach (Abstractions.ParamAttrInfo pai in pi.ParamAttrInfos)
                {
                    ParamAttrInfo paramAttrInfo = new ParamAttrInfo
                    {
                        Data = pai.Data,
                        Type = pai.Type,
                        Parent = paramInfo
                    };

                    paramInfo.ParamAttrInfos.Add(paramAttrInfo);
                }

                eventTarget.ParamInfos.Add(paramInfo);
            }

            return eventTarget;
        }

        private Conditional ReadConditional(Abstractions.Conditional c, object parent)
        {
            Conditional conditional = new Conditional
            {
                Id = c.Id,
                OutputNodePosition = ReadThreePointValue(c.OutputNodePosition),
                Root = c.Root,
                Parent = parent
            };

            foreach (Abstractions.Computation comp in c.Computations)
            {
                Computation computation = new Computation
                {
                    Chance = comp.Chance,
                    Comparison = comp.Comparison,
                    ControlCondition = comp.ControlCondition,
                    ControlValue = comp.ControlValue,
                    CValue = comp.CValue,
                    Id = comp.Id,
                    IsNot = comp.IsNot,
                    MethodName = comp.MethodName,
                    MethodParameters = comp.MethodParameters,
                    Type = comp.Type,
                    UiPosition = ReadThreePointValue(comp.UiPosition),
                    UnitGroup = comp.UnitGroup,
                    VehicleControl = comp.VehicleControl,
                    Parent = conditional
                };

                if (!string.IsNullOrWhiteSpace(comp.Type) && comp.ObjectReference.HasValue)
                {
                    //if (comp.Type == KeywordStrings.SccUnit)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccUnitGroup)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccUnitList)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccChance)
                    //{

                    //}
                    //else if (comp.Type == KeywordStrings.SccVehicleControl)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccGlobalValue)
                    //{
                    //}
                    // only static objects seem to use the object reference property
                    if (comp.Type == KeywordStrings.SccStaticObject)
                    {
                        if (comp.ObjectReference.Value == -1)
                        {
                            computation.ObjectReference = comp.ObjectReference.Value;
                        }
                        else
                        {
                            StaticObject staticObject = StaticObjects.FirstOrDefault(x => x.Id == comp.ObjectReference.Value);

                            if (staticObject == null)
                            {
                                WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the computation {comp.Id} on conditinal {c.Id} references static object {comp.ObjectReference.Value} and that static object could not be found in the list of StaticObjects.");
                            }
                            else
                            {
                                computation.ObjectReference = staticObject;
                            }
                        }
                    }
                    else
                    {
                        computation.ObjectReference = comp.ObjectReference.Value;
                    }
                }

                if (comp.GlobalValue.HasValue)
                {
                    GlobalValue globalValue = GlobalValues.FirstOrDefault(x => x.Index == comp.GlobalValue);

                    if (globalValue == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the computation {comp.Id} on conditinal {c.Id} references global value {comp.GlobalValue} and that global value could not be found in the list of GlobalValues.");
                    }
                    else
                    {
                        computation.GlobalValue = globalValue;
                    }
                }

                if (comp.Unit.HasValue)
                {
                    UnitSpawner unit = Units.FirstOrDefault(x => x.UnitInstanceId == comp.Unit);

                    if (unit == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the computation {comp.Id} on conditinal {c.Id} references unit {comp.Unit} and that unit could not be found in the list of Units.");
                    }
                    else
                    {
                        computation.Unit = unit;
                    }
                }

                if (!string.IsNullOrWhiteSpace(comp.UnitList))
                {
                    string[] units = comp.UnitList.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string unit in units)
                    {
                        int id = Convert.ToInt32(unit);

                        UnitSpawner u = Units.FirstOrDefault(x => x.UnitInstanceId == id);

                        if (u == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the computation {comp.Id} on conditinal {c.Id} references unit {id} in the unit list {comp.UnitList} and that unit could not be found in the list of Units.");
                        }
                        else
                        {
                            computation.UnitList.Add(u);
                        }
                    }
                }

                conditional.Computations.Add(computation);
            }

            // loop through a second time to assign the factors property because it is a list of other computations
            // (loop a second time because I am not sure if the order of COMPs is guaranteed)
            for (int i = 0; i < conditional.Computations.Count; i++)
            {
                Computation computation = conditional.Computations[i];
                Abstractions.Computation com = c.Computations[i];

                if (!string.IsNullOrWhiteSpace(com.Factors))
                {
                    string[] comps = com.Factors.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string factor in comps)
                    {
                        int id = Convert.ToInt32(factor);

                        Computation item = conditional.Computations.FirstOrDefault(x => x.Id == id);

                        if (item == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: computation {com.Id} references other computations in its factors property. Computation {id} in the factors list could not be found in the list of compuations for conditional {conditional.Id}.");
                        }
                        else
                        {
                            computation.Factors.Add(item);
                        }
                    }
                }
            }

            return conditional;
        }

        private Objective ReadObjective(Abstractions.Objective o)
        {
            Objective objective = new Objective
            {
                AutoSetWaypoint = o.AutoSetWaypoint,
                CompletionReward = o.CompletionReward,
                ObjectiveID = o.ObjectiveID,
                ObjectiveInfo = o.ObjectiveInfo,
                ObjectiveName = o.ObjectiveName,
                ObjectiveType = o.ObjectiveType,
                OrderID = o.OrderID,
                Required = o.Required,
                StartMode = o.StartMode,
                Parent = this
            };

            objective.CompleteEvent = ReadEventInfo(o.CompleteEvent, objective, true, true);
            objective.FailEvent = ReadEventInfo(o.FailEvent, objective, true, true);
            objective.StartEvent = ReadEventInfo(o.StartEvent, objective, true, true);

            int id;

            if (o.Waypoint != KeywordStrings.Null)
            {
                if (o.Waypoint.StartsWith(KeywordStrings.UnitWaypoint, StringComparison.OrdinalIgnoreCase))
                {
                    id = Convert.ToInt32(o.Waypoint.Replace(KeywordStrings.UnitWaypoint, ""));

                    UnitSpawner unit = Units.FirstOrDefault(x => x.UnitInstanceId == id);

                    if (unit == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} references unit {id} as a waypoint. The unit could not be found in the list of Units.");
                    }
                    else
                    {
                        objective.Waypoint = unit;
                    }
                }
                else
                {
                    id = Convert.ToInt32(o.Waypoint);

                    Waypoint waypoint = Waypoints.FirstOrDefault(x => x.Id == id);

                    if (waypoint == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} references waypoint {id} as a waypoint. The waypoint could not be found in the list of Waypoints.");
                    }
                    else
                    {
                        objective.Waypoint = waypoint;
                    }
                }
            }

            ObjectiveFields objectiveFields = new ObjectiveFields
            {
                CompletionMode = o.Fields.CompletionMode,
                FuelLevel = o.Fields.FuelLevel,
                FullCompletionBonus = o.Fields.FullCompletionBonus,
                MinRequired = o.Fields.MinRequired,
                PerUnitReward = o.Fields.PerUnitReward,
                Radius = o.Fields.Radius,
                SphericalRadius = o.Fields.SphericalRadius,
                TriggerRadius = o.Fields.TriggerRadius,
                UnloadRadius = o.Fields.UnloadRadius,
                Parent = objective
            };

            if (o.Fields.FailConditional.HasValue)
            {
                Conditional conditional = Conditionals.FirstOrDefault(x => x.Id == o.Fields.FailConditional.Value);

                if (conditional == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a fail conditional {o.Fields.FailConditional.Value} and that conditional could not be found in the list of Conditionals.");
                }
                else
                {
                    objectiveFields.FailConditional = conditional;
                }
            }

            if (o.Fields.SuccessConditional.HasValue)
            {
                Conditional conditional = Conditionals.FirstOrDefault(x => x.Id == o.Fields.SuccessConditional.Value);

                if (conditional == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a success conditional {o.Fields.SuccessConditional.Value} and that conditional could not be found in the list of Conditionals.");
                }
                else
                {
                    objectiveFields.SuccessConditional = conditional;
                }
            }

            if (o.Fields.DropoffRallyPoint.HasValue)
            {
                Waypoint waypoint = Waypoints.FirstOrDefault(x => x.Id == o.Fields.DropoffRallyPoint.Value);

                if (waypoint == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a drop off rally point waypoint {o.Fields.DropoffRallyPoint.Value} and that waypoint could not be found in the list of Waypoints.");
                }
                else
                {
                    objectiveFields.DropoffRallyPoint = waypoint;
                }
            }

            if (o.Fields.Target.HasValue)
            {
                UnitSpawner unit = Units.FirstOrDefault(x => x.UnitInstanceId == o.Fields.Target.Value);

                if (unit == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a unit reference as target {o.Fields.Target.Value} and that unit could not be found in the list of Units.");
                }
                else
                {
                    objectiveFields.Target = unit;
                }
            }

            if (o.Fields.TargetUnit.HasValue)
            {
                UnitSpawner unit = Units.FirstOrDefault(x => x.UnitInstanceId == o.Fields.TargetUnit.Value);

                if (unit == null)
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a unit reference as target unit {o.Fields.TargetUnit.Value} and that unit could not be found in the list of Units.");
                }
                else
                {
                    objectiveFields.TargetUnit = unit;
                }
            }

            if (!string.IsNullOrWhiteSpace(o.Fields.Targets))
            {
                string[] units = o.Fields.Targets.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string unit in units)
                {
                    id = Convert.ToInt32(unit);

                    UnitSpawner u = Units.FirstOrDefault(x => x.UnitInstanceId == id);

                    if (u == null)
                    {
                        WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a unit reference in targets {o.Fields.Targets} and that unit could not be found in the list of Units.");
                    }
                    else
                    {
                        objectiveFields.Targets.Add(u);
                    }
                }
            }

            objective.Fields = objectiveFields;

            return objective;
        }

        private ThreePointValue ReadThreePointValue(string value)
        {
            value = value.Trim().Replace("(", "").Replace(")", "");
            string[] values = value.Split(',', StringSplitOptions.RemoveEmptyEntries);

            return new ThreePointValue
            {
                X = Convert.ToSingle(values[0]),
                Y = Convert.ToSingle(values[1]),
                Z = Convert.ToSingle(values[2]),
            };
        }

        private void SetObjectivePreReqs(int index, bool opFor)
        {
            Objective objective = opFor ? ObjectivesOpFor[index] : Objectives[index];
            Abstractions.Objective o = opFor ? customScenario.ObjectivesOpFor[index] : customScenario.Objectives[index];

            if (!string.IsNullOrWhiteSpace(o.PreReqObjectives))
            {
                string[] objs = o.PreReqObjectives.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in objs)
                {
                    int id = Convert.ToInt32(s);

                    if (opFor)
                    {
                        Objective match = ObjectivesOpFor.FirstOrDefault(x => x.ObjectiveID == id);

                        if (match == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a prerequisite objective {id} that could not be found in the List of ObjectivesOpFor.");
                        }
                        else
                        {
                            objective.PreReqObjectives.Add(match);
                        }
                    }
                    else
                    {
                        Objective match = Objectives.FirstOrDefault(x => x.ObjectiveID == id);

                        if (match == null)
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario No Matching Id Data Warning: the objective {o.ObjectiveName} has a prerequisite objective {id} that could not be found in the List of Objectives.");
                        }
                        else
                        {
                            objective.PreReqObjectives.Add(match);
                        }
                    }
                }
            }
        }

        public bool Save()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                // we will create a new custom scenario object and not overwrite the original we have at the class level
                Abstractions.CustomScenario cs = new Abstractions.CustomScenario
                {
                    AllowedEquips = AllowedEquips,
                    BaseBudget = BaseBudget,
                    CampaignId = CampaignId,
                    CampaignOrderIndex = CampaignOrderIndex,
                    EnvironmentName = EnvironmentName,
                    EquipsConfigurable = EquipsConfigurable,
                    ForcedEquips = ForcedEquips,
                    ForceEquips = ForceEquips,
                    FuelDrainMultiplier = FuelDrainMultiplier,
                    GameVersion = GameVersion,
                    InfiniteAmmo = InfiniteAmmo,
                    InfiniteAmmoReloadDelay = InfiniteAmmoReloadDelay,
                    IsTraining = IsTraining,
                    MapId = MapId,
                    Multiplayer = Multiplayer,
                    NormalForcedFuel = NormalForcedFuel,
                    QuickSaveLimit = QuickSaveLimit,
                    QuickSaveMode = QuickSaveMode,
                    ScenarioDescription = ScenarioDescription,
                    ScenarioId = ScenarioId,
                    ScenarioName = ScenarioName,
                    SelectableEnvironment = SelectableEnvironment,
                    Vehicle = Vehicle,
                    File = File,
                    HasError = HasError
                };

                if (ReturnToBaseWaypoint != null)
                {
                    if (ReturnToBaseWaypoint is UnitSpawner unitSpawner)
                    {
                        cs.ReturnToBaseWaypointId = $"{KeywordStrings.UnitWaypoint}{unitSpawner.UnitInstanceId}";
                    }

                    if (ReturnToBaseWaypoint is Waypoint waypoint)
                    {
                        cs.ReturnToBaseWaypointId = $"{KeywordStrings.WptWaypoint}{waypoint.Id}";
                    }
                }

                if (RefuelWaypoint != null)
                {
                    if (RefuelWaypoint is UnitSpawner unitSpawner)
                    {
                        cs.RefuelWaypointId = $"{KeywordStrings.UnitWaypoint}{unitSpawner.UnitInstanceId}";
                    }

                    if (RefuelWaypoint is Waypoint waypoint)
                    {
                        cs.RefuelWaypointId = $"{KeywordStrings.WptWaypoint}{waypoint.Id}";
                    }
                }

                foreach (BaseInfo baseInfo in Bases)
                {
                    Abstractions.BaseInfo bi = new Abstractions.BaseInfo
                    {
                        Id = baseInfo.Id,
                        BaseTeam = baseInfo.BaseTeam,
                        OverrideBaseName = baseInfo.OverrideBaseName
                    };

                    cs.Bases.Add(bi);
                }

                foreach (BriefingNote briefingNote in BriefingNotes)
                {
                    Abstractions.BriefingNote bn = new Abstractions.BriefingNote
                    {
                        AudioClipPath = briefingNote.AudioClipPath,
                        ImagePath = briefingNote.ImagePath,
                        Text = briefingNote.Text
                    };

                    cs.BriefingNotes.Add(bn);
                }

                foreach (GlobalValue globalValue in GlobalValues)
                {
                    Abstractions.GlobalValue gv = new Abstractions.GlobalValue
                    {
                        Description = globalValue.Description,
                        Index = globalValue.Index,
                        Name = globalValue.Name,
                        Value = globalValue.Value
                    };

                    cs.GlobalValues.Add(gv);
                }

                foreach (Path path in Paths)
                {
                    Abstractions.Path p = new Abstractions.Path
                    {
                        Id = path.Id,
                        Loop = path.Loop,
                        Name = path.Name,
                        PathMode = path.PathMode,
                        Points = string.Join(';', path.Points.Select(x => x.ToString())) + ";"
                    };

                    cs.Paths.Add(p);
                }

                foreach (Resource resource in ResourceManifest)
                {
                    Abstractions.Resource r = new Abstractions.Resource
                    {
                        Index = resource.Index,
                        Path = resource.Path
                    };

                    cs.ResourceManifest.Add(r);
                }

                foreach (StaticObject staticObject in StaticObjects)
                {
                    Abstractions.StaticObject so = new Abstractions.StaticObject
                    {
                        GlobalPosition = staticObject.GlobalPosition.ToString(),
                        Id = staticObject.Id,
                        PrefabId = staticObject.PrefabId,
                        Rotation = staticObject.Rotation.ToString()
                    };

                    cs.StaticObjects.Add(so);
                }

                foreach (Waypoint waypoint in Waypoints)
                {
                    Abstractions.Waypoint wp = new Abstractions.Waypoint
                    {
                        GlobalPoint = waypoint.GlobalPoint.ToString(),
                        Id = waypoint.Id,
                        Name = waypoint.Name
                    };

                    cs.Waypoints.Add(wp);
                }

                for (int i = 0; i < Waypoints.GetPropertyCount(); i++)
                {
                    DictionaryEntry property = Waypoints.GetProperty(i);

                    cs.Waypoints.AddProperty(property.Key, property.Value);
                }

                foreach (UnitSpawner unit in Units)
                {
                    Abstractions.UnitSpawner us = new Abstractions.UnitSpawner
                    {
                        EditorPlacementMode = unit.EditorPlacementMode,
                        GlobalPosition = unit.GlobalPosition.ToString(),
                        LastValidPlacement = unit.LastValidPlacement.ToString(),
                        Rotation = unit.Rotation.ToString(),
                        SpawnChance = unit.SpawnChance,
                        SpawnFlags = unit.SpawnFlags,
                        UnitId = unit.UnitId,
                        UnitInstanceId = unit.UnitInstanceId,
                        UnitName = unit.UnitName
                    };

                    Abstractions.UnitFields uf = new Abstractions.UnitFields
                    {
                        AllowReload = unit.UnitFields.AllowReload,
                        AutoRefuel = unit.UnitFields.AutoRefuel,
                        AutoReturnToBase = unit.UnitFields.AutoReturnToBase,
                        AwacsVoiceProfile = unit.UnitFields.AwacsVoiceProfile,
                        Behavior = unit.UnitFields.Behavior,
                        CombatTarget = unit.UnitFields.CombatTarget,
                        CommsEnabled = unit.UnitFields.CommsEnabled,
                        DefaultBehavior = unit.UnitFields.DefaultBehavior,
                        DefaultNavSpeed = unit.UnitFields.DefaultNavSpeed,
                        DefaultOrbitPoint = unit.UnitFields.DefaultOrbitPoint,
                        DefaultPath = unit.UnitFields.DefaultPath,
                        DefaultRadarEnabled = unit.UnitFields.DefaultRadarEnabled,
                        DefaultShotsPerSalvo = unit.UnitFields.DefaultShotsPerSalvo,
                        DefaultWaypoint = unit.UnitFields.DefaultWaypoint,
                        DetectionMode = unit.UnitFields.DetectionMode,
                        EngageEnemies = unit.UnitFields.EngageEnemies,
                        Fuel = unit.UnitFields.Fuel,
                        HullNumber = unit.UnitFields.HullNumber,
                        InitialSpeed = unit.UnitFields.InitialSpeed,
                        Invincible = unit.UnitFields.Invincible,
                        MoveSpeed = unit.UnitFields.MoveSpeed,
                        OrbitAltitude = unit.UnitFields.OrbitAltitude,
                        ParkedStartMode = unit.UnitFields.ParkedStartMode,
                        PlayerCommandsMode = unit.UnitFields.PlayerCommandsMode,
                        RadarUnits = unit.UnitFields.RadarUnits,
                        ReceiveFriendlyDamage = unit.UnitFields.ReceiveFriendlyDamage,
                        ReloadTime = unit.UnitFields.ReloadTime,
                        Respawnable = unit.UnitFields.Respawnable,
                        RippleRate = unit.UnitFields.RippleRate,
                        SpawnOnStart = unit.UnitFields.SpawnOnStart,
                        StartMode = unit.UnitFields.StartMode,
                        StopToEngage = unit.UnitFields.StopToEngage,
                        UnitGroup = unit.UnitFields.UnitGroup,
                        VoiceProfile = unit.UnitFields.VoiceProfile,
                    };

                    IReadOnlyList<string> unitFieldProperties = Abstractions.UnitFields.GetUnitFieldsForUnitType(unit.UnitId);

                    if (unitFieldProperties.Contains(KeywordStrings.WaypointProperty))
                    {
                        if (unit.UnitFields.Waypoint == null)
                        {
                            uf.Waypoint = KeywordStrings.Null;
                        }
                        else
                        {
                            uf.Waypoint = unit.UnitFields.Waypoint.Id.ToString();
                        }
                    }
                    
                    if (unitFieldProperties.Contains(KeywordStrings.CarrierSpawns))
                    {
                        // do I do something to ensure the correct number of units in the property based on ship type?
                        if (unit.UnitId == KeywordStrings.EscortCruiser) // 1 unit
                        {
                        }
                        else if (unit.UnitId == KeywordStrings.AlliedAaShip) // 6 units
                        {
                        }
                        else if (unit.UnitId == KeywordStrings.AlliedCarrier) // 9 units
                        {
                        }
                        else if (unit.UnitId == KeywordStrings.EnemyCarrier) // 10 units
                        {
                        }

                        List<string> unitsOnCarrier = unit.UnitFields.CarrierSpawns.Select(x => $"{x.Item1}:{x.Item2.UnitInstanceId}").ToList();

                        if (unitsOnCarrier.Count > 0)
                        {
                            uf.CarrierSpawns = string.Join(';', unitsOnCarrier) + ";";
                        }
                    }
                    
                    if (unitFieldProperties.Contains(KeywordStrings.RtbDestination))
                    {
                        if (unit.UnitFields.ReturnToBaseDestination is UnitSpawner u)
                        {
                            uf.ReturnToBaseDestination = $"{KeywordStrings.UnitWaypoint}{u.UnitInstanceId}";
                        }
                        else if (unit.UnitFields.ReturnToBaseDestination is BaseInfo bi)
                        {
                            // base references seem to be index based not id based
                            BaseInfo match = Bases.FirstOrDefault(x => x.Id == bi.Id);

                            if (match == null) uf.ReturnToBaseDestination = KeywordStrings.MapWaypoint + "-1";
                            else uf.ReturnToBaseDestination = KeywordStrings.MapWaypoint + Bases.IndexOf(match).ToString();
                        }
                    }
                    
                    if (unitFieldProperties.Contains(KeywordStrings.Equips))
                    {
                        uf.Equips = unit.UnitFields.Equips;
                    }

                    us.UnitFields = uf;

                    cs.Units.Add(us);
                }

                foreach (UnitGroup unitGroup in UnitGroups)
                {
                    Abstractions.UnitGroup ug = new Abstractions.UnitGroup
                    {
                        Name = unitGroup.Name
                    };

                    ug.Alpha = WriteUnitGroup(unitGroup.Alpha);
                    ug.Bravo = WriteUnitGroup(unitGroup.Bravo);
                    ug.Charlie = WriteUnitGroup(unitGroup.Charlie);
                    ug.Delta = WriteUnitGroup(unitGroup.Delta);
                    ug.Echo = WriteUnitGroup(unitGroup.Echo);
                    ug.Foxtrot = WriteUnitGroup(unitGroup.Foxtrot);
                    ug.Golf = WriteUnitGroup(unitGroup.Golf);
                    ug.Hotel = WriteUnitGroup(unitGroup.Hotel);
                    ug.India = WriteUnitGroup(unitGroup.India);
                    ug.Juliet = WriteUnitGroup(unitGroup.Juliet);
                    ug.Kilo = WriteUnitGroup(unitGroup.Kilo);
                    ug.Lima = WriteUnitGroup(unitGroup.Lima);
                    ug.Mike = WriteUnitGroup(unitGroup.Mike);
                    ug.November = WriteUnitGroup(unitGroup.November);
                    ug.Oscar = WriteUnitGroup(unitGroup.Oscar);
                    ug.Papa = WriteUnitGroup(unitGroup.Papa);
                    ug.Quebec = WriteUnitGroup(unitGroup.Quebec);
                    ug.Romeo = WriteUnitGroup(unitGroup.Romeo);
                    ug.Sierra = WriteUnitGroup(unitGroup.Sierra);
                    ug.Tango = WriteUnitGroup(unitGroup.Tango);
                    ug.Uniform = WriteUnitGroup(unitGroup.Uniform);
                    ug.Victor = WriteUnitGroup(unitGroup.Victor);
                    ug.Whiskey = WriteUnitGroup(unitGroup.Whiskey);
                    ug.Xray = WriteUnitGroup(unitGroup.Xray);
                    ug.Yankee = WriteUnitGroup(unitGroup.Yankee);
                    ug.Zulu = WriteUnitGroup(unitGroup.Zulu);

                    ug.UnitGroupSettings.AddRange(WriteUnitGroupSettings(unitGroup));

                    cs.UnitGroups.Add(ug);
                }

                foreach (Conditional conditional in Conditionals)
                {
                    cs.Conditionals.Add(WriteConditional(conditional));
                }

                foreach (TriggerEvent trigger in TriggerEvents)
                {
                    Abstractions.TriggerEvent te = new Abstractions.TriggerEvent
                    {
                        Enabled = trigger.Enabled,
                        EventInfo = WriteEventInfo(trigger.EventInfo),
                        EventName = trigger.EventName,
                        Id = trigger.Id,
                        ProxyMode = trigger.ProxyMode,
                        Radius = trigger.Radius,
                        SphericalRadius = trigger.SphericalRadius,
                        TriggerMode = trigger.TriggerMode,
                        TriggerType = trigger.TriggerType,
                    };

                    if (trigger.Conditional != null)
                    {
                        te.Conditional = trigger.Conditional.Id;
                    }

                    if (trigger.Waypoint != null)
                    {
                        te.Waypoint = trigger.Waypoint.Id;
                    }

                    cs.TriggerEvents.Add(te);
                }

                foreach (Sequence sequence in EventSequences)
                {
                    Abstractions.Sequence s = new Abstractions.Sequence
                    {
                        Id = sequence.Id,
                        SequenceName = sequence.SequenceName,
                        StartImmediately = sequence.StartImmediately,
                        WhileLoop = sequence.WhileLoop
                    };

                    foreach (Event @event in sequence.Events)
                    {
                        Abstractions.Event e = new Abstractions.Event
                        {
                            Delay = @event.Delay,
                            NodeName = @event.NodeName,
                            EventInfo = WriteEventInfo(@event.EventInfo)
                        };

                        if (@event.Conditional != null)
                        {
                            e.Conditional = @event.Conditional.Id;
                        }

                        if (@event.ExitConditional != null)
                        {
                            e.ExitConditional = @event.ExitConditional.Id;
                        }

                        s.Events.Add(e);
                    }

                    cs.EventSequences.Add(s);
                }

                foreach (ConditionalAction conditionalAction in ConditionalActions)
                {
                    Abstractions.ConditionalAction ca = new Abstractions.ConditionalAction
                    {
                        Id = conditionalAction.Id,
                        Name = conditionalAction.Name,
                    };

                    Abstractions.Block baseBlock = new Abstractions.Block
                    {
                        BlockId = conditionalAction.BaseBlock.BlockId,
                        BlockName = conditionalAction.BaseBlock.BlockName
                    };

                    baseBlock.Actions = WriteEventInfo(conditionalAction.BaseBlock.Actions);
                    baseBlock.Conditional = WriteConditional(conditionalAction.BaseBlock.Conditional);
                    baseBlock.ElseActions = WriteEventInfo(conditionalAction.BaseBlock.ElseActions);

                    foreach (Block elseIfBlock in conditionalAction.BaseBlock.ElseIfBlocks)
                    {
                        Abstractions.Block eib = new Abstractions.Block
                        {
                            BlockId = elseIfBlock.BlockId,
                            BlockName = elseIfBlock.BlockName
                        };

                        eib.Actions = WriteEventInfo(elseIfBlock.Actions);
                        eib.Conditional = WriteConditional(elseIfBlock.Conditional);
                        eib.ElseActions = WriteEventInfo(elseIfBlock.ElseActions);

                        baseBlock.ElseIfBlocks.Add(eib);
                    }

                    ca.BaseBlock = baseBlock;

                    cs.ConditionalActions.Add(ca);
                }

                foreach (Objective objective in Objectives)
                {
                    cs.Objectives.Add(WriteObjective(objective));
                }

                foreach (Objective objective in ObjectivesOpFor)
                {
                    cs.ObjectivesOpFor.Add(WriteObjective(objective));
                }

                foreach (TimedEventGroup timedEventGroup in TimedEventGroups)
                {
                    Abstractions.TimedEventGroup teg = new Abstractions.TimedEventGroup
                    {
                        BeginImmediately = timedEventGroup.BeginImmediately,
                        GroupId = timedEventGroup.GroupId,
                        GroupName = timedEventGroup.GroupName,
                        InitialDelay = timedEventGroup.InitialDelay
                    };

                    foreach (TimedEventInfo timedEventInfo in timedEventGroup.TimedEventInfos)
                    {
                        Abstractions.TimedEventInfo tei = new Abstractions.TimedEventInfo
                        {
                            EventName = timedEventInfo.EventName,
                            Time = timedEventInfo.Time
                        };

                        foreach (EventTarget eventTarget in timedEventInfo.EventTargets)
                        {
                            tei.EventTargets.Add(WriteEventTarget(eventTarget));
                        }

                        teg.TimedEventInfos.Add(tei);
                    }

                    cs.TimedEventGroups.Add(teg);
                }

                sw.Stop();

                if (DiagnosticOptions.OutputCustomScenarioConversionTime)
                    Debug.WriteLine($"VTS.Data.Runtime.CustomScenario converted to VTS.Data.Abstractions.CustomScenario:{sw.Elapsed}");

                Abstractions.CustomScenario.WriteVtsFile(cs);

                return true;
            }
            catch (Exception ex)
            {
                WriteWarning($"An exception occurred attempting to save the custom scenario.{Environment.NewLine}{ex}");

                return false;
            }
        }

        private string WriteUnitGroup(UnitGroupGrouping unitGroupGrouping)
        {
            if (unitGroupGrouping == null) return null;

            List<int> unitIds = unitGroupGrouping.Units.Select(x => x.UnitInstanceId).ToList();
            string units = string.Join(';', unitIds) + ";";

            return units;
        }

        private List<Abstractions.UnitGroupSettings> WriteUnitGroupSettings(UnitGroup unitGroup)
        {
            List<Abstractions.UnitGroupSettings> unitGroupSettings = new List<Abstractions.UnitGroupSettings>();

            if (unitGroup.Alpha.Settings != null)
            {
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Alpha?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Bravo?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Charlie?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Delta?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Echo?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Foxtrot?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Golf?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Hotel?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.India?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Juliet?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Kilo?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Lima?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Mike?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.November?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Oscar?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Papa?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Quebec?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Romeo?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Sierra?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Tango?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Uniform?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Victor?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Whiskey?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Xray?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Yankee?.Settings));
                unitGroupSettings.Add(WriteUnitGroupSetting(unitGroup.Zulu?.Settings));
            }

            return unitGroupSettings;
        }

        private Abstractions.UnitGroupSettings WriteUnitGroupSetting(UnitGroupSettings unitGroupSettingsObj)
        {
            if (unitGroupSettingsObj != null)
            {
                Abstractions.UnitGroupSettings ugs = new Abstractions.UnitGroupSettings
                {
                    Name = unitGroupSettingsObj.Name,
                    SyncAltSpawns = unitGroupSettingsObj.SyncAltSpawns,
                };

                return ugs;
            }
            else return null;
        }

        private Abstractions.Conditional WriteConditional(Conditional conditional)
        {
            Abstractions.Conditional con = new Abstractions.Conditional
            {
                Id = conditional.Id,
                OutputNodePosition = conditional.OutputNodePosition.ToString(),
                Root = conditional.Root
            };

            foreach (Computation computation in conditional.Computations)
            {
                Abstractions.Computation c = new Abstractions.Computation
                {
                    Chance = computation.Chance,
                    Comparison = computation.Comparison,
                    ControlCondition = computation.ControlCondition,
                    ControlValue = computation.ControlValue,
                    CValue = computation.CValue,
                    GlobalValue = computation.GlobalValue?.Index,
                    Id = computation.Id,
                    IsNot = computation.IsNot,
                    MethodName = computation.MethodName,
                    MethodParameters = computation.MethodParameters,
                    Type = computation.Type,
                    UiPosition = computation.UiPosition.ToString(),
                    Unit = computation.Unit?.UnitInstanceId,
                    UnitGroup = computation.UnitGroup,
                    VehicleControl = computation.VehicleControl
                };

                if (computation.Factors.Count > 0)
                {
                    c.Factors = string.Join(';', computation.Factors.Select(x => x.Id).ToList()) + ";";
                }

                if (computation.ObjectReference != null)
                {
                    int? id = computation.ObjectReference == null ? null : computation.ObjectReference is StaticObject staticObject ? staticObject.Id : (int)computation.ObjectReference;

                    c.ObjectReference = id;
                }

                if (computation.UnitList.Count > 0)
                {
                    c.UnitList = string.Join(';', computation.UnitList.Select(x => x.UnitInstanceId).ToList()) + ";";
                }

                con.Computations.Add(c);
            }

            return con;
        }

        private Abstractions.EventInfo WriteEventInfo(EventInfo eventInfo)
        {
            Abstractions.EventInfo ei = new Abstractions.EventInfo
            {
                EventName = eventInfo.EventName
            };

            foreach (EventTarget eventTarget in eventInfo.EventTargets)
            {
                ei.EventTargets.Add(WriteEventTarget(eventTarget));
            }

            return ei;
        }

        private Abstractions.EventTarget WriteEventTarget(EventTarget eventTarget)
        {
            Abstractions.EventTarget et = new Abstractions.EventTarget
            {
                EventName= eventTarget.EventName,
                MethodName= eventTarget.MethodName,
                TargetType = eventTarget.TargetType,
            };

            if (et.TargetType == KeywordStrings.EventTargetUnit)
            {
                if (eventTarget.Target is UnitSpawner unit)
                {
                    et.TargetId = unit.UnitInstanceId;
                }
                else
                {
                    et.TargetId = -1;

                    WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the EventTarget.Target [{et.EventName}] listed as a unit could not be cast as a unit. Setting TargetId to -1.");
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetEventSequences)
            {
                if (eventTarget.Target is Sequence sequence)
                {
                    et.TargetId = sequence.Id;
                }
                else
                {
                    et.TargetId = -1;

                    WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the EventTarget.Target [{et.EventName}] listed as a sequence could not be cast as a sequence. Setting TargetId to -1.");
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetTriggerEvents)
            {
                if (eventTarget.Target is TriggerEvent triggerEvent)
                {
                    et.TargetId = triggerEvent.Id;
                }
                else
                {
                    et.TargetId = -1;

                    WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the EventTarget.Target [{et.EventName}] listed as a trigger event could not be cast as a trigger event. Setting TargetId to -1.");
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetStaticObject)
            {
                if  (eventTarget.Target is StaticObject staticObject)
                {
                    et.TargetId = staticObject.Id;
                }
                else
                {
                    et.TargetId = -1;

                    WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the EventTarget.Target [{et.EventName}] listed as a static object could not be cast as a static object. Setting TargetId to -1.");
                }
            }
            else if (et.TargetType == KeywordStrings.EventTargetUnitGroup)
            {
                et.TargetId = (int)eventTarget.Target; // just unbox the int that represents the group because I am not sure how these map
            }
            else if (et.TargetType == KeywordStrings.System)
            {
                et.TargetId = (int)eventTarget.Target; // just unbox the 0 as I don't believe it is used for system
            }

            foreach (ParamInfo paramInfo in eventTarget.ParamInfos)
            {
                Abstractions.ParamInfo pi = new Abstractions.ParamInfo
                {
                    Name = paramInfo.Name,
                    Type = paramInfo.Type
                };

                /*
                 * System.Boolean : value = False || True
                 * System.Single : value = 1 || 1.0
                 * UnitReference : value = -1:0 (this means empty I guess) || 6 (UnitSpawner object)
                 * UnitReferenceListAI : value = 0;7; (; separated list of unit ids)
                 * UnitReferenceListOtherSubs : value = 157;158;179;180;183;184;260;261;312;178;152;154;159; (; separated list of unit ids)
                 * ConditionalActionReference : value = 0 (id of action)
                 * AirportReference : value = map:0 (base -> BaseInfo object) || unit:0 (UnitSpawner object)
                 * VTSAudioReference : value = null (path on hard drive)
                 * GlobalValue : value = 0 (index of global value)
                 * FollowPath : value = 23 (id of path)
                 * Waypoint : value = 8 (id of waypoint)
                 * FixedPoint : value = (52126.018064498901, 2258.798828125, 38374.517822265625) (ThreePointValue)
                 * System.String : value = '' (or any other string)
                 * Teams : value = Allied || Enemy
                 * GroundUnitSpawn+MoveSpeeds : value = Fast_30 || Medium_20 || Slow_10
                 * SmokeFlare+FlareColors : value = Blue
                 */

                if (pi.Type == KeywordStrings.SystemBoolean)
                {
                    if (paramInfo.Value != null)
                    {
                        pi.Value = (bool)paramInfo.Value ? KeywordStrings.True : KeywordStrings.False;
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.SystemSingle)
                {
                    if (paramInfo.Value != null)
                    {
                        pi.Value = ((float)paramInfo.Value).ToString();
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.UnitReference)
                {
                    if (paramInfo.Value == null)
                    {
                        pi.Value = "-1:0";
                    }
                    else 
                    {
                        UnitSpawner unit = paramInfo.Value as UnitSpawner;

                        if (unit != null)
                        {
                            pi.Value = unit.UnitInstanceId.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a unit reference that could not be cast as a unit to read data from.");

                            pi.Value = "-1:0";
                        }
                    }
                }
                else if (pi.Type == KeywordStrings.UnitReferenceListAI  || pi.Type == KeywordStrings.UnitReferenceListOtherSubs)
                {
                    if (paramInfo.Value != null)
                    {
                        List<UnitSpawner> paramInfoUnits = paramInfo.Value as List<UnitSpawner>;

                        if (paramInfoUnits != null)
                        {
                            List<int> unitIds = paramInfoUnits.Select(u => u.UnitInstanceId).ToList();

                            if (unitIds.Count > 0)
                                pi.Value = string.Join(";", unitIds) + ";";
                            else
                                pi.Value = string.Empty;
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a list of units reference that could not be cast as a list of units to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.ConditionalActionReference)
                {
                    if (paramInfo.Value != null)
                    {
                        ConditionalAction ca = paramInfo.Value as ConditionalAction;

                        if (ca != null)
                        {
                            pi.Value = ca.Id.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a conditional action reference that could not be cast as a conditional action to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.AirportReference)
                {
                    if (paramInfo.Value != null)
                    {
                        if (paramInfo.Value is BaseInfo baseInfo)
                        {
                            if (baseInfo == null) pi.Value = KeywordStrings.MapWaypoint + "-1";
                            else
                            {
                                BaseInfo match = Bases.FirstOrDefault(x => x.Id == baseInfo.Id);

                                if (match == null) pi.Value = KeywordStrings.MapWaypoint + "-1";
                                else pi.Value = KeywordStrings.MapWaypoint + Bases.IndexOf(match).ToString();
                            }
                        }
                        else if (paramInfo.Value is UnitSpawner unit)
                        {
                            if (unit == null) pi.Value = KeywordStrings.UnitWaypoint + "-1";
                            else
                            {
                                UnitSpawner match = Units.FirstOrDefault(u => u.UnitInstanceId == unit.UnitInstanceId);

                                if (match == null) pi.Value = KeywordStrings.UnitWaypoint + "-1";
                                else pi.Value = KeywordStrings.UnitWaypoint + unit.UnitInstanceId.ToString();
                            }
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a value reference that could not be cast as a base or a unit to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.VTSAudioReference)
                {
                    if (paramInfo.Value != null)
                    {
                        FileInfo fi = paramInfo.Value as FileInfo;

                        if (fi != null)
                        {
                            pi.Value = fi.FullName.Replace(EditorResourcesPath, "");
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a file info reference that could not be cast as a file info to read data from.");

                            pi.Value = KeywordStrings.Null;
                        }
                    }
                    else
                    {
                        pi.Value = KeywordStrings.Null;
                    }
                }
                else if (pi.Type == KeywordStrings.GlobalValueParamInfoType)
                {
                    if (paramInfo.Value != null)
                    {
                        GlobalValue gv = paramInfo.Value as GlobalValue;

                        if (gv != null)
                        {
                            pi.Value = gv.Index.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a global value reference that could not be cast as a global value to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.FollowPath)
                {
                    if (paramInfo.Value != null)
                    {
                        Path path = paramInfo.Value as Path;

                        if (path != null)
                        {
                            pi.Value = path.Id.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a path reference that could not be cast as a path to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.WaypointParamInfoType)
                {
                    if (paramInfo.Value != null)
                    {
                        Waypoint waypoint = paramInfo.Value as Waypoint;

                        if (waypoint != null)
                        {
                            pi.Value = waypoint.Id.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a waypoint reference that could not be cast as a waypoint to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.FixedPoint)
                {
                    if (paramInfo.Value != null)
                    {
                        ThreePointValue tpv = paramInfo.Value as ThreePointValue;

                        if (tpv != null)
                        {
                            pi.Value = tpv.ToString();
                        }
                        else
                        {
                            WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: the ParamInfo object with name {pi.Name} and the type of {pi.Type} has a waypoint reference that could not be cast as a waypoint to read data from.");

                            pi.Value = string.Empty;
                        }
                    }
                    else
                    {
                        pi.Value = string.Empty;
                    }
                }
                else if (pi.Type == KeywordStrings.SystemString || pi.Type == KeywordStrings.Teams ||
                         pi.Type == KeywordStrings.GroundUnitSpawnPlusMoveSpeeds || pi.Type == KeywordStrings.SmokeFlarePlusFlareColors)
                {
                    pi.Value = paramInfo.Value == null ? string.Empty : paramInfo.Value.ToString();
                }

                foreach (ParamAttrInfo paramAttrInfo in paramInfo.ParamAttrInfos)
                {
                    Abstractions.ParamAttrInfo pai = new Abstractions.ParamAttrInfo
                    {
                        Data = paramAttrInfo.Data,
                        Type = paramAttrInfo.Type
                    };

                    pi.ParamAttrInfos.Add(pai);
                }

                et.ParamInfos.Add(pi);
            }

            return et;
        }

        private Abstractions.Objective WriteObjective(Objective objective)
        {
            Abstractions.Objective obj = new Abstractions.Objective
            {
                AutoSetWaypoint = objective.AutoSetWaypoint,
                CompletionReward = objective.CompletionReward,
                ObjectiveID = objective.ObjectiveID,
                ObjectiveInfo = objective.ObjectiveInfo,
                ObjectiveName = objective.ObjectiveName,
                ObjectiveType = objective.ObjectiveType,
                OrderID = objective.OrderID,
                Required = objective.Required,
                StartMode = objective.StartMode
            };

            obj.CompleteEvent = WriteEventInfo(objective.CompleteEvent);
            obj.FailEvent = WriteEventInfo(objective.FailEvent);
            obj.StartEvent = WriteEventInfo(objective.StartEvent);

            if (objective.Waypoint != null)
            {
                if (objective.Waypoint is UnitSpawner unit)
                {
                    obj.Waypoint = $"{KeywordStrings.UnitWaypoint}{unit.UnitInstanceId}";
                }
                else if (objective.Waypoint is Waypoint waypoint)
                {
                    obj.Waypoint = waypoint.Id.ToString();
                }
                else
                {
                    WriteWarning($"VTS.Data.Runtime.CustomScenario Data Conversion Warning: could not convert the Objective.Waypoint for objective [{objective.ObjectiveName}] to either a unit or a waypoint type.");
                }
            }

            Abstractions.ObjectiveFields objectiveFields = new Abstractions.ObjectiveFields
            {
                CompletionMode = objective.Fields.CompletionMode,
                FuelLevel = objective.Fields.FuelLevel,
                FullCompletionBonus = objective.Fields.FullCompletionBonus,
                MinRequired = objective.Fields.MinRequired,
                PerUnitReward = objective.Fields.PerUnitReward,
                Radius = objective.Fields.Radius,
                SphericalRadius = objective.Fields.SphericalRadius,
                TriggerRadius = objective.Fields.TriggerRadius,
                UnloadRadius = objective.Fields.UnloadRadius
            };

            if (objective.Fields.FailConditional != null)
            {
                objectiveFields.FailConditional = objective.Fields.FailConditional.Id;
            }

            if (objective.Fields.SuccessConditional != null)
            {
                objectiveFields.SuccessConditional = objective.Fields.SuccessConditional.Id;
            }

            if (objective.Fields.DropoffRallyPoint != null)
            {
                objectiveFields.DropoffRallyPoint = objective.Fields.DropoffRallyPoint.Id;
            }

            if (objective.Fields.Target != null)
            {
                objectiveFields.Target = objective.Fields.Target.UnitInstanceId;
            }

            if (objective.Fields.TargetUnit != null)
            {
                objectiveFields.TargetUnit = objective.Fields.TargetUnit.UnitInstanceId;
            }

            if (objective.Fields.Targets.Count > 0)
            {
                objectiveFields.Targets = string.Join(';', objective.Fields.Targets.Select(x => x.UnitInstanceId).ToList()) + ";";
            }

            obj.Fields = objectiveFields;

            return obj;
        }

        #endregion
    }
}
