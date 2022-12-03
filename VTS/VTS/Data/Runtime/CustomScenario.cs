using System.Diagnostics;
using VTS.Collections;

namespace VTS.Data.Runtime
{
    /// <summary>A managed wrapper for the VTS file.</summary>
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenario : ICloneable
    {
        #region Fields

        private Abstractions.CustomScenario customScenario;

        #endregion

        #region Properties

        public string AllowedEquips { get; set; }
        public int BaseBudget { get; set; }
        public string CampaignId { get; set; }
        public int CampaignOrderIndex { get; set; }
        public bool EquipsConfigurable { get; set; }
        public string EnvironmentName { get; set; }
        public bool ForceEquips { get; set; }
        public string ForcedEquips { get; set; }
        public string GameVersion { get; set; }
        public bool IsTraining { get; set; }
        public string MapId { get; set; }
        public bool Multiplayer { get; set; }
        public int NormalForcedFuel { get; set; }
        public int QuickSaveLimit { get; set; }
        public string QuickSaveMode { get; set; }
        public string RefuelWaypointId { get; set; }
        public string ReturnToBaseWaypointId { get; set; }
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

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        public CustomScenario()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        /// <param name="scenario">The custom scenario reference from the Abstraction namespace containing the data from the VTS file.</param>
        /// <exception cref="ArgumentException">Abstraction.CustomScenario.File cannot be null, empty of consist of white-space characters only.</exception>
        /// <exception cref="TypeInitializationException">Occurs if there is an issue during the conversion of the data.</exception>
        public CustomScenario(Abstractions.CustomScenario scenario)
        {
            if (string.IsNullOrWhiteSpace(scenario.File))
                throw new ArgumentException("Abstraction.CustomScenario.File cannot be null, empty of consist of white-space characters only.");

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
            return new CustomScenario
            {
                AllowedEquips = AllowedEquips,
                BaseBudget = BaseBudget,
                CampaignId = CampaignId,
                CampaignOrderIndex = CampaignOrderIndex,
                EquipsConfigurable = EquipsConfigurable,
                EnvironmentName = EnvironmentName,
                ForceEquips = ForceEquips,
                ForcedEquips = ForcedEquips,
                GameVersion = GameVersion,
                IsTraining = IsTraining,
                MapId = MapId,
                Multiplayer = Multiplayer,
                NormalForcedFuel = NormalForcedFuel,
                QuickSaveLimit = QuickSaveLimit,
                QuickSaveMode = QuickSaveMode,
                RefuelWaypointId = RefuelWaypointId,
                ReturnToBaseWaypointId = ReturnToBaseWaypointId,
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
        }

        private void Initialize()
        {
            HasError = customScenario.HasError;
            File = customScenario.File;

            if (!customScenario.HasError)
                ReadData();
        }

        private void ReadData()
        {
            try
            {
                AllowedEquips = customScenario.AllowedEquips;
                BaseBudget = customScenario.BaseBudget;
                CampaignId = customScenario.CampaignId;
                CampaignOrderIndex = customScenario.CampaignOrderIndex;
                EquipsConfigurable = customScenario.EquipsConfigurable;
                EnvironmentName = customScenario.EnvironmentName;
                ForceEquips = customScenario.ForceEquips;
                ForcedEquips = customScenario.ForcedEquips;
                GameVersion = customScenario.GameVersion;
                IsTraining = customScenario.IsTraining;
                MapId = customScenario.MapId;
                Multiplayer = customScenario.Multiplayer;
                NormalForcedFuel = customScenario.NormalForcedFuel;
                QuickSaveLimit = customScenario.QuickSaveLimit;
                QuickSaveMode = customScenario.QuickSaveMode;
                RefuelWaypointId = customScenario.RefuelWaypointId;
                ReturnToBaseWaypointId = customScenario.ReturnToBaseWaypointId;
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

                    foreach (ThreePointValue tpv in p.Points)
                    {
                        path.Points.Add(tpv.Clone());
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
                        GlobalPosition = so.GlobalPosition.Clone(),
                        Id = so.Id,
                        PrefabId = so.PrefabId,
                        Rotation = so.Rotation.Clone(),
                        Parent = this
                    };

                    StaticObjects.Add(staticObject);
                }

                foreach (Abstractions.Waypoint w in customScenario.Waypoints)
                {
                    Waypoint waypoint = new Waypoint
                    {
                        GlobalPoint = w.GlobalPoint.Clone(),
                        Id = w.Id,
                        Name = w.Name,
                        Parent = this
                    };

                    Waypoints.Add(waypoint);
                }

                foreach (Abstractions.UnitSpawner us in customScenario.Units)
                {
                    UnitSpawner unit = new UnitSpawner
                    {
                        EditorPlacementMode = us.EditorPlacementMode,
                        GlobalPosition = us.GlobalPosition.Clone(),
                        LastValidPlacement = us.LastValidPlacement.Clone(),
                        Rotation = us.Rotation.Clone(),
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
                        Equips = us.UnitFields.Equips,
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
                        RippleRate = us.UnitFields.RippleRate,
                        SpawnOnStart = us.UnitFields.SpawnOnStart,
                        StartMode = us.UnitFields.StartMode,
                        StopToEngage = us.UnitFields.StopToEngage,
                        UnitGroup = us.UnitFields.UnitGroup,
                        VoiceProfile = us.UnitFields.VoiceProfile,
                        Parent = unit
                    };

                    if (us.UnitFields.Waypoint != "null")
                    {
                        int id = Convert.ToInt32(us.UnitFields.Waypoint);

                        unit.UnitFields.Waypoint = Waypoints.First(w => w.Id == id);
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

                            // there should be a match so do not use FirstOrDefault, if there is not
                            // match then there has been some kind of error processing the data
                            UnitSpawner carrierSpawn = Units.First(theUnit => theUnit.UnitInstanceId == unitId); 

                            unit.UnitFields.CarrierSpawns.Add(new Tuple<int, UnitSpawner>(index, carrierSpawn));
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(u.UnitFields.ReturnToBaseDestination))
                    {
                        if (u.UnitFields.ReturnToBaseDestination.StartsWith("map")) // BaseInfo object
                        {
                            string[] values = u.UnitFields.ReturnToBaseDestination.Split(':');
                            int id = Convert.ToInt32(values[1]);

                            // there should be a match so do not use FirstOrDefault, if there is not
                            // match then there has been some kind of error processing the data
                            BaseInfo rtb = Bases.First(a => a.Id == id);

                            unit.UnitFields.ReturnToBaseDestination = rtb;
                        }
                        else if (u.UnitFields.ReturnToBaseDestination.StartsWith("unit")) // UnitSpawner object
                        {
                            string[] values = u.UnitFields.ReturnToBaseDestination.Split(':');
                            int id = Convert.ToInt32(values[1]);

                            // there should be a match so do not use FirstOrDefault, if there is not
                            // match then there has been some kind of error processing the data
                            UnitSpawner rtb = Units.First(theUnit => theUnit.UnitInstanceId == id);

                            unit.UnitFields.ReturnToBaseDestination = rtb;
                        }
                    }
                }

                foreach (Abstractions.UnitGroup ug in customScenario.UnitGroups)
                {

                }

                /*
                 * get types that depend on other types
                 */
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

                    EventInfo actionsEventInfo = new EventInfo
                    {
                        EventName = ca.BaseBlock.Actions.EventName,
                        Parent = baseBlock
                    };

                    foreach (Abstractions.EventTarget et in ca.BaseBlock.Actions.EventTargets)
                    {
                        EventTarget eventTarget = new EventTarget
                        {
                            EventName = et.EventName,
                            MethodName = et.MethodName,
                            TargetId = et.TargetId,
                            TargetType = et.TargetType,
                            Parent = actionsEventInfo
                        };

                        foreach (Abstractions.ParamInfo pi in et.ParamInfos)
                        {

                        }
                    }

                    Conditional conditional = new Conditional
                    {
                        Id = ca.BaseBlock.Conditional.Id,
                        OutputNodePosition = ca.BaseBlock.Conditional.OutputNodePosition.Clone(),
                        Root = ca.BaseBlock.Conditional.Root,
                        Parent = baseBlock
                    };

                    ConditionalActions.Add(conditionalAction);
                }

                foreach (Abstractions.Conditional c in customScenario.Conditionals)
                {

                }

                foreach (Abstractions.Sequence s in customScenario.EventSequences)
                {

                }

                foreach (Abstractions.Objective o in customScenario.Objectives)
                {

                }

                foreach (Abstractions.Objective o in customScenario.ObjectivesOpFor)
                {

                }

                foreach (Abstractions.TimedEventGroup teg in customScenario.TimedEventGroups)
                {

                }

                foreach (Abstractions.TriggerEvent te in customScenario.TriggerEvents)
                {

                }          
            }
            catch (Exception ex)
            {
                throw new TypeInitializationException("VTS.Data.Runtime.CustomScenario", ex);
            }
        }

        #endregion
    }
}
