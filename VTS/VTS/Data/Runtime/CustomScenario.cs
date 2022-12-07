﻿using System.Diagnostics;
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
                    UnitGroup unitGroup = new UnitGroup
                    {
                        Name = ug.Name, // ALLIED or ENEMY
                        Parent = this
                    };

                    unitGroup.Alpha = ReadUnitGroup(ug, "Alpha", ug.Alpha);
                    unitGroup.Bravo = ReadUnitGroup(ug, "Bravo", ug.Bravo);
                    unitGroup.Charlie = ReadUnitGroup(ug, "Charlie", ug.Charlie);
                    unitGroup.Delta = ReadUnitGroup(ug, "Delta", ug.Delta);
                    unitGroup.Echo = ReadUnitGroup(ug, "Echo", ug.Echo);
                    unitGroup.Foxtrot = ReadUnitGroup(ug, "Foxtrot", ug.Foxtrot);
                    unitGroup.Golf = ReadUnitGroup(ug, "Golf", ug.Golf);
                    unitGroup.Hotel = ReadUnitGroup(ug, "Hotel", ug.Hotel);
                    unitGroup.India = ReadUnitGroup(ug, "India", ug.India);
                    unitGroup.Juliet = ReadUnitGroup(ug, "Juliet", ug.Juliet);
                    unitGroup.Kilo = ReadUnitGroup(ug, "Kilo", ug.Kilo);
                    unitGroup.Lima = ReadUnitGroup(ug, "Lima", ug.Lima);
                    unitGroup.Mike = ReadUnitGroup(ug, "Mike", ug.Mike);
                    unitGroup.November = ReadUnitGroup(ug, "November", ug.November);
                    unitGroup.Oscar = ReadUnitGroup(ug, "Oscar", ug.Oscar);
                    unitGroup.Papa = ReadUnitGroup(ug, "Papa", ug.Papa);
                    unitGroup.Quebec = ReadUnitGroup(ug, "Quebec", ug.Quebec);
                    unitGroup.Romeo = ReadUnitGroup(ug, "Romeo", ug.Romeo);
                    unitGroup.Sierra = ReadUnitGroup(ug, "Sierra", ug.Sierra);
                    unitGroup.Tango = ReadUnitGroup(ug, "Tango", ug.Tango);
                    unitGroup.Uniform = ReadUnitGroup(ug, "Uniform", ug.Uniform);
                    unitGroup.Victor = ReadUnitGroup(ug, "Victor", ug.Victor);
                    unitGroup.Whiskey = ReadUnitGroup(ug, "Whiskey", ug.Whiskey);
                    unitGroup.Xray = ReadUnitGroup(ug, "Xray", ug.Xray);
                    unitGroup.Yankee = ReadUnitGroup(ug, "Yankee", ug.Yankee);
                    unitGroup.Zulu = ReadUnitGroup(ug, "Zulu", ug.Zulu);

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

                    baseBlock.Actions = ReadEventInfo(ca.BaseBlock.Actions, baseBlock);
                    baseBlock.Conditional = ReadConditional(ca.BaseBlock.Conditional, baseBlock);
                    baseBlock.ElseActions = ReadEventInfo(ca.BaseBlock.ElseActions, baseBlock);

                    foreach (Abstractions.Block eib in ca.BaseBlock.ElseIfBlocks)
                    {
                        Block elseIfBlock = new Block
                        {
                            BlockId = eib.BlockId,
                            BlockName = eib.BlockName,
                            Parent = baseBlock
                        };

                        elseIfBlock.Actions = ReadEventInfo(eib.Actions, elseIfBlock);
                        elseIfBlock.Conditional = ReadConditional(eib.Conditional, elseIfBlock);
                        elseIfBlock.ElseActions = ReadEventInfo(eib.ElseActions, elseIfBlock);

                        baseBlock.ElseIfBlocks.Add(elseIfBlock);
                    }

                    conditionalAction.BaseBlock = baseBlock;

                    ConditionalActions.Add(conditionalAction);
                }

                foreach (Abstractions.Sequence s in customScenario.EventSequences)
                {
                    Sequence sequence = new Sequence
                    {
                        Id = s.Id,
                        SequenceName = s.SequenceName,
                        StartImmediately = s.StartImmediately,
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

                        @event.EventInfo = ReadEventInfo(e.EventInfo, sequence);
                        @event.Conditional = Conditionals.First(x => x.Id == e.Conditional); // should always be a match, error if not

                        if (e.ExitConditional.HasValue)
                        {
                            @event.ExitConditional = Conditionals.First(x => x.Id == e.ExitConditional.Value); // should always be a match, error if not
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
                            timedEventInfo.EventTargets.Add(ReadEventTarget(et, timedEventInfo));
                        }

                        timedEventGroup.TimedEventInfos.Add(timedEventInfo);
                    }

                    TimedEventGroups.Add(timedEventGroup);
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

                    triggerEvent.EventInfo = ReadEventInfo(te.EventInfo, triggerEvent);

                    if (te.Conditional.HasValue)
                    {
                        triggerEvent.Conditional = Conditionals.First(x => x.Id == te.Conditional.Value);
                    }

                    if (te.Waypoint.HasValue)
                    {
                        triggerEvent.Waypoint = Waypoints.First(x => x.Id == te.Waypoint.Value);
                    }

                    TriggerEvents.Add(triggerEvent);
                }          
            }
            catch (Exception ex)
            {
                throw new TypeInitializationException("VTS.Data.Runtime.CustomScenario", ex);
            }
        }

        private UnitGroupGrouping ReadUnitGroup(Abstractions.UnitGroup ug, string group, string groupUnits)
        {
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

            string[] unitsIds = groupUnits.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (string unitId in unitsIds)
            {
                int id = Convert.ToInt32(unitId);

                UnitSpawner unit = Units.First(u => u.UnitInstanceId == id); // should always be a match, error if not

                /*
                 * Note: there seems to be an issue with VTOL VR for unit groups. Sometimes units are repeated
                 * within the same group and will often times appear in multiple groups incorrectly. Units can
                 * only be assigned to one group. Validate both of these and throw warning out to Debug console.
                 * Also, put data in the correct location based on UnitSpawner.UnitFields.UnitGroup data.
                 */

                // check if the unit even belongs with this group (check UnitSpawner.UnitFields.UnitGroup)
                if (!string.IsNullOrWhiteSpace(unit.UnitFields.UnitGroup) || unit.UnitFields.UnitGroup != "null")
                {
                    string[] groupData = unit.UnitFields.UnitGroup.Split(':');

                    // should match "enemy" or "allied"
                    if (groupData[0].Equals(ugs.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        if (groupData[1] != group)
                        {
                            Debug.WriteLine($"VTS.Data.Runtime.CustomScenario UnitGroup Data WARNING: The unit is not assigned to the correct group. Unit is supposed to be included in {groupData[1]} but it is listed in {group} incorrectly. Skipping unit.");

                            continue;
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"VTS.Data.Runtime.CustomScenario UnitGroup Data WARNING: The unit is not assigned to the correct larger group of groups. Current group: {ugs.Name}, listed group for unit: {groupData[0]}. This means an Allied unit appeared in a Enemy group or Enemy unit appeared in an Allied group. Skipping unit.");

                        continue;
                    }
                }

                // check duplicity, should be ok to check the instance because all instances come from the Units collection
                if (groupGrouping.Units.Contains(unit))
                    Debug.WriteLine($"VTS.Data.Runtime.CustomScenario UnitGroup Data WARNING: Unit {unit.UnitName} (unitInstanceID = {unit.UnitInstanceId}) is already a part of this group. Duplicate ID entry for the same unit within the same group ({group}). Skipping duplicate.");
                else
                    groupGrouping.Units.Add(unit); // if not a duplicate and we are in the correct group, assign unit
            }

            return groupGrouping;
        }

        private EventInfo ReadEventInfo(Abstractions.EventInfo ei, object parent)
        {
            EventInfo eventInfo = new EventInfo
            {
                EventName = ei.EventName,
                Parent = parent
            };

            foreach (Abstractions.EventTarget et in ei.EventTargets)
            {
                eventInfo.EventTargets.Add(ReadEventTarget(et, eventInfo));
            }

            return eventInfo;
        }

        private EventTarget ReadEventTarget(Abstractions.EventTarget et, object parent)
        {
            EventTarget eventTarget = new EventTarget
            {
                EventName = et.EventName,
                MethodName = et.MethodName,
                //TargetId = et.TargetId,
                TargetType = et.TargetType,
                Parent = parent
            };

            // UnitSpawner.UnitInstanceId is TargetId when making Abstraction equivalent 
            eventTarget.Target = Units.First(u => u.UnitInstanceId == et.TargetId); // should always be a match, error if not

            foreach (Abstractions.ParamInfo pi in et.ParamInfos)
            {
                ParamInfo paramInfo = new ParamInfo
                {
                    Name = pi.Name,
                    Type = pi.Type,
                    Value = pi.Value,
                    Parent = eventTarget
                };

                // this will be very complex and tedious to track down all the various types of objects that can be referenced here
                //string value = pi.Value; // this will be an int, a string, a Unit, a list of Units, a Path, a Waypoint, ???
                // todo

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
                OutputNodePosition = c.OutputNodePosition.Clone(),
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
                    UiPosition = comp.UiPosition,
                    UnitGroup = comp.UnitGroup,
                    VehicleControl = comp.VehicleControl,                    
                    Parent = conditional
                };

                if (!string.IsNullOrWhiteSpace(comp.Type) && comp.ObjectReference.HasValue)
                {
                    if (comp.Type == "SCCStaticObject")
                    {
                        computation.ObjectReference = StaticObjects.First(x => x.Id == comp.ObjectReference.Value); // should always be a match, error if not
                    }
                    // todo : identify if there can be other object types
                    else
                    {
                        computation.ObjectReference = comp.ObjectReference;
                    }
                }

                if (comp.GlobalValue.HasValue)
                {
                    computation.GlobalValue = GlobalValues.First(x => x.Index == comp.GlobalValue); // should always be a match, error if not
                }

                if (comp.Unit.HasValue)
                {
                    computation.Unit = Units.First(x => x.UnitInstanceId == comp.Unit);  // should always be a match, error if not
                }

                if (!string.IsNullOrWhiteSpace(comp.UnitList))
                {
                    string[] units = comp.UnitList.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string unit in units)
                    {
                        int id = Convert.ToInt32(unit);

                        computation.UnitList.Add(Units.First(x => x.UnitInstanceId == id)); // should always be a match, error if not
                    }
                }

                conditional.Computations.Add(computation);
            }

            // loop through a second time to assign the factors property because it is a list of other computations
            // (loop a second time because I am not sure if the order of COMPs is guaranteed)
            for (int i = 0; i < conditional.Computations.Count; i++)
            {
                Computation computation = conditional.Computations[i];
                Abstractions.Computation con = c.Computations[i];

                if (!string.IsNullOrWhiteSpace(con.Factors))
                {
                    string[] comps = con.Factors.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string factor in comps)
                    {
                        int id = Convert.ToInt32(factor);

                        Computation item = conditional.Computations.First(x => x.Id == id); // should always be a match, error if not

                        computation.Factors.Add(item);
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

            objective.CompleteEvent = ReadEventInfo(o.CompleteEvent, objective);
            objective.FailEvent = ReadEventInfo(o.FailEvent, objective);
            objective.StartEvent = ReadEventInfo(o.StartEvent, objective);

            int id;

            if (o.Waypoint != "null")
            {
                id = Convert.ToInt32(o.Waypoint);

                objective.Waypoint = Waypoints.First(x => x.Id == id); // should always be a match, error if not
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
                objectiveFields.FailConditional = Conditionals.First(x => x.Id == o.Fields.FailConditional.Value); // should always be a match, error if not
            }

            if (o.Fields.SuccessConditional.HasValue)
            {
                objectiveFields.SuccessConditional = Conditionals.First(x => x.Id == o.Fields.SuccessConditional.Value); // should always be a match, error if not
            }

            if (o.Fields.DropoffRallyPoint.HasValue)
            {
                objectiveFields.DropoffRallyPoint = Waypoints.First(x => x.Id == o.Fields.DropoffRallyPoint.Value); // should always be a match, error if not
            }            

            if (o.Fields.Target.HasValue)
            {
                objectiveFields.Target = Units.First(x => x.UnitInstanceId == o.Fields.Target.Value); // should always be a match, error if not
            }

            if (o.Fields.TargetUnit.HasValue)
            {
                objectiveFields.TargetUnit = Units.First(x => x.UnitInstanceId == o.Fields.TargetUnit.Value); // should always be a match, error if not
            }

            if (!string.IsNullOrWhiteSpace(o.Fields.Targets))
            {
                string[] units = o.Fields.Targets.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (string unit in units)
                {
                    id = Convert.ToInt32(unit);

                    objectiveFields.Targets.Add(Units.First(x => x.UnitInstanceId == id)); // should always be a match, error if not
                }
            }

            objective.Fields = objectiveFields;

            return objective;
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
                        objective.PreReqObjectives.Add(Objectives.First(x => x.ObjectiveID == id)); // should always be a match, error if not
                    else
                        objective.PreReqObjectives.Add(ObjectivesOpFor.First(x => x.ObjectiveID == id)); // should always be a match, error if not
                }
            }
        }

        public bool Save()
        {
            return true;
        }

        #endregion
    }
}