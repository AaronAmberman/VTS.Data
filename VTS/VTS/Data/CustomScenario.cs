﻿using System.Diagnostics;
using VTS.Collections;
using VTS.Data.Diagnostics;
using VTS.Data.Raw;
using VTS.File;

namespace VTS.Data
{
    /// <summary>A managed wrapper for the VTS file.</summary>
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenario
    {
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

        /// <summary>Gets or sets whether or not there was a read or write error.</summary>
        public bool HasError { get; set; }

        /// <summary>Gets or sets the file reference for CustomScenario object.</summary>
        public string File { get; set; }

        /// <summary>Get or sets the the diagnostic options to use when reading and writing the VTS file.</summary>
        public static DiagnosticOptions ReadWriteDiagnosticOptions { get; set; } = new DiagnosticOptions();

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        /// <remarks>
        /// For constructing a blank CustomScenario object. If you wish to get a CustomScenario that 
        /// represents the contents of a VTS file please use the static method ReadVtsFile.
        /// </remarks>
        public CustomScenario()
        {
        }

        #endregion

        #region Methods

        private static void ReadCustomScenarioProperties(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            foreach (VtsProperty property in cs.Properties)
            {
                if (property.Name == "gameVersion")
                    scenario.GameVersion = property.Value;
                if (property.Name == "campaignID")
                    scenario.CampaignId = property.Value;
                if (property.Name == "campaignOrderIdx")
                    scenario.CampaignOrderIndex = Convert.ToInt32(property.Value);
                if (property.Name == "scenarioName")
                    scenario.ScenarioName = property.Value;
                if (property.Name == "scenarioID")
                    scenario.ScenarioId = property.Value;
                if (property.Name == "scenarioDescription")
                    scenario.ScenarioDescription = property.Value;
                if (property.Name == "mapID")
                    scenario.MapId = property.Value;
                if (property.Name == "vehicle")
                    scenario.Vehicle = property.Value;
                if (property.Name == "multiplayer")
                    scenario.Multiplayer = Convert.ToBoolean(property.Value);
                if (property.Name == "allowedEquips")
                    scenario.AllowedEquips = property.Value;
                if (property.Name == "forcedEquips")
                    scenario.ForcedEquips = property.Value;
                if (property.Name == "forceEquips")
                    scenario.ForceEquips = Convert.ToBoolean(property.Value);
                if (property.Name == "normForcedFuel")
                    scenario.NormalForcedFuel = Convert.ToInt32(property.Value);
                if (property.Name == "equipsConfigurable")
                    scenario.EquipsConfigurable = Convert.ToBoolean(property.Value);
                if (property.Name == "baseBudget")
                    scenario.BaseBudget = Convert.ToInt32(property.Value);
                if (property.Name == "isTraining")
                    scenario.IsTraining = Convert.ToBoolean(property.Value);
                if (property.Name == "rtbWptID")
                    scenario.ReturnToBaseWaypointId = property.Value;
                if (property.Name == "refuelWptID")
                    scenario.RefuelWaypointId = property.Value;
                if (property.Name == "envName")
                    scenario.EnvironmentName = property.Value;
                if (property.Name == "selectableEnv")
                    scenario.SelectableEnvironment = Convert.ToBoolean(property.Value);
                if (property.Name == "qsMode")
                    scenario.QuickSaveMode = property.Value;
                if (property.Name == "qsLimit")
                    scenario.QuickSaveLimit = Convert.ToInt32(property.Value);
            }
        }

        private static void ReadUnits(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject units = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Units);

            if (units == null)
            {
                // do we throw an error or not? force the units block to be required?
                return;
            }

            foreach (VtsObject unit in units.Children)
            {
                UnitSpawner unitSpawner = new UnitSpawner();

                foreach (VtsProperty property in unit.Properties)
                {
                    if (property.Name == "unitName")
                        unitSpawner.UnitName = property.Value;
                    if (property.Name == "globalPosition")
                        unitSpawner.GlobalPosition = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                    if (property.Name == "unitInstanceID")
                        unitSpawner.UnitInstanceId = Convert.ToInt32(property.Value);
                    if (property.Name == "unitID")
                        unitSpawner.UnitId = property.Value;
                    if (property.Name == "rotation")
                        unitSpawner.Rotation = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                    if (property.Name == "spawnChance")
                        unitSpawner.SpawnChance = Convert.ToInt32(property.Value);
                    if (property.Name == "lastValidPlacement")
                        unitSpawner.LastValidPlacement = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                    if (property.Name == "spawnFlags")
                        unitSpawner.SpawnFlags = property.Value;
                }

                // every unit will have one child object, the unit fields object
                UnitFields uf = new UnitFields();
                VtsObject unitFields = unit.Children[0];

                foreach (VtsProperty ufProperty in unitFields.Properties)
                {
                    if (ufProperty.Name == "unitGroup")
                        uf.UnitGroup = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "defaultBehavior")
                        uf.DefaultBehavior = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "defaultWaypoint")
                        uf.DefaultWaypoint = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "defaultPath")
                        uf.DefaultPath = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "hullNumber")
                        uf.HullNumber = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "engageEnemies")
                        uf.EngageEnemies = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "detectionMode")
                        uf.DetectionMode = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "spawnOnStart")
                        uf.SpawnOnStart = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "invincible")
                        uf.Invincible = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "carrierSpawns")
                        uf.CarrierSpawns = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "radarUnits")
                        uf.RadarUnits = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "allowReload")
                        uf.AllowReload = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "reloadTime")
                        uf.ReloadTime = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "combatTarget")
                        uf.CombatTarget = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "moveSpeed")
                        uf.MoveSpeed = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "behavior")
                        uf.Behavior = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "waypoint")
                        uf.Waypoint = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "voiceProfile")
                        uf.VoiceProfile = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "playerCommandsMode")
                        uf.PlayerCommandsMode = ufProperty.Value;
                    if (ufProperty.Name == "initialSpeed")
                        uf.InitialSpeed = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "defaultNavSpeed")
                        uf.DefaultNavSpeed = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "defaultOrbitPoint")
                        uf.DefaultOrbitPoint = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "orbitAltitude")
                        uf.OrbitAltitude = Convert.ToSingle(ufProperty.Value);
                    if (ufProperty.Name == "fuel")
                        uf.Fuel = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "autoRefuel")
                        uf.AutoRefuel = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "autoRTB")
                        uf.AutoReturnToBase = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "rtbDestination")
                        uf.ReturnToBaseDestination = ufProperty.Value;
                    if (ufProperty.Name == "parkedStartMode")
                        uf.ParkedStartMode = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "equips")
                        uf.Equips = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "stopToEngage")
                        uf.StopToEngage = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "startMode")
                        uf.StartMode = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "receiveFriendlyDamage")
                        uf.ReceiveFriendlyDamage = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "defaultRadarEnabled")
                        uf.DefaultRadarEnabled = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "awacsVoiceProfile")
                        uf.AwacsVoiceProfile = ufProperty.Value == "null" ? null : ufProperty.Value;
                    if (ufProperty.Name == "commsEnabled")
                        uf.CommsEnabled = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == "defaultShotsPerSalvo")
                        uf.DefaultShotsPerSalvo = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == "rippleRate")
                        uf.RippleRate = Convert.ToInt32(ufProperty.Value);
                }

                unitSpawner.UnitFields = uf;

                scenario.Units.Add(unitSpawner);

                if (ReadWriteDiagnosticOptions.OutputUnitFieldsGroups)
                    VtsDiagnosticHelper.UnitAndFields.Add(new Tuple<VtsObject, VtsObject>(unit, unitFields));
            }

            if (ReadWriteDiagnosticOptions.OutputUnitFieldsGroups)
                VtsDiagnosticHelper.OutputUnitFieldGroups();
        }

        private static void ReadPaths(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject paths = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Paths);

            if (paths == null)
            {
                // do we throw an error or not? force the paths block to be required?
                return;
            }

            foreach (VtsObject path in paths.Children)
            {
                Path p = new Path();

                foreach (VtsProperty property in path.Properties)
                {
                    if (property.Name == "id")
                        p.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "name")
                        p.Name = property.Value;
                    if (property.Name == "loop")
                        p.Loop = Convert.ToBoolean(property.Value);
                    if (property.Name == "points")
                    {
                        string[] points = property.Value.Split(';', StringSplitOptions.RemoveEmptyEntries);
                        List<ThreePointValue> pointValues = new List<ThreePointValue>();

                        foreach (string point in points)
                        {
                            pointValues.Add(ReadThreePointValue(point.Replace("(", "").Replace(")", "")));
                        }

                        p.Points = pointValues;
                    }
                    if (property.Name == "pathMode")
                        p.PathMode = property.Value;
                }

                scenario.Paths.Add(p);
            }
        }

        private static void ReadWaypoints(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject waypoints = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Waypoints);

            if (waypoints == null)
            {
                // do we throw an error or not? force the waypoints block to be required?
                return;
            }

            foreach (VtsProperty property in waypoints.Properties)
            {
                scenario.Waypoints.AddProperty(property.Name, property.Value);
            }

            foreach (VtsObject waypoint in waypoints.Children)
            {
                Waypoint w = new Waypoint();

                foreach (VtsProperty property in waypoint.Properties)
                {
                    if (property.Name == "id")
                        w.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "name")
                        w.Name = property.Value;
                    if (property.Name == "globalPoint")
                        w.GlobalPoint = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                }

                scenario.Waypoints.Add(w);
            }
        }

        private static void ReadUnitGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject unitGroups = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.UnitGroups);

            if (unitGroups == null)
            {
                // do we throw an error or not? force the unit groups block to be required?
                return;
            }

            foreach (VtsObject ug in unitGroups.Children)
            {
                UnitGroup unitGroup = new UnitGroup();
                unitGroup.Name = ug.Name; // should be ALLIED or ENEMY

                foreach (VtsProperty property in ug.Properties)
                {
                    if (property.Name == "Alpha")
                        unitGroup.Alpha = property.Value;
                    if (property.Name == "Bravo")
                        unitGroup.Bravo = property.Value;
                    if (property.Name == "Charlie")
                        unitGroup.Charlie = property.Value;
                    if (property.Name == "Delta")
                        unitGroup.Delta = property.Value;
                    if (property.Name == "Echo")
                        unitGroup.Echo = property.Value;
                    if (property.Name == "Foxtrot")
                        unitGroup.Foxtrot = property.Value;
                    if (property.Name == "Golf")
                        unitGroup.Golf = property.Value;
                    if (property.Name == "Hotel")
                        unitGroup.Hotel = property.Value;
                    if (property.Name == "India")
                        unitGroup.India = property.Value;
                    if (property.Name == "Juliet")
                        unitGroup.Juliet = property.Value;
                    if (property.Name == "Kilo")
                        unitGroup.Kilo = property.Value;
                    if (property.Name == "Lima")
                        unitGroup.Lima = property.Value;
                    if (property.Name == "Mike")
                        unitGroup.Mike = property.Value;
                    if (property.Name == "November")
                        unitGroup.November = property.Value;
                    if (property.Name == "Oscar")
                        unitGroup.Oscar = property.Value;
                    if (property.Name == "Papa")
                        unitGroup.Papa = property.Value;
                    if (property.Name == "Quebec")
                        unitGroup.Quebec = property.Value;
                    if (property.Name == "Romeo")
                        unitGroup.Romeo = property.Value;
                    if (property.Name == "Sierra")
                        unitGroup.Sierra = property.Value;
                    if (property.Name == "Tango")
                        unitGroup.Tango = property.Value;
                    if (property.Name == "Uniform")
                        unitGroup.Uniform = property.Value;
                    if (property.Name == "Victor")
                        unitGroup.Victor = property.Value;
                    if (property.Name == "Whiskey")
                        unitGroup.Whiskey = property.Value;
                    if (property.Name == "Xray")
                        unitGroup.Xray = property.Value;
                    if (property.Name == "Yankee")
                        unitGroup.Yankee = property.Value;
                    if (property.Name == "Zulu")
                        unitGroup.Zulu = property.Value;
                }

                foreach (VtsObject child in ug.Children)
                {
                    UnitGroupSettings unitGroupSettings = new UnitGroupSettings
                    {
                        Name = child.Name // should be Alpha_SETTINGS, Bravo_SETTINGS, etc.
                    };

                    foreach (VtsProperty settingProperty in child.Properties)
                    {
                        if (settingProperty.Name == "syncAltSpawns")
                            unitGroupSettings.SyncAltSpawns = settingProperty.Value;
                    }

                    unitGroup.UnitGroupSettings.Add(unitGroupSettings);
                }

                scenario.UnitGroups.Add(unitGroup);
            }
        }

        private static void ReadTimedEventGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject timedEventGroups = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.TimedEventGroups);

            if (timedEventGroups == null)
            {
                // do we throw an error or not? force the timed event groups block to be required?
                return;
            }

            foreach (VtsObject teg in timedEventGroups.Children)
            {
                TimedEventGroup timedEventGroup = new TimedEventGroup();

                foreach (VtsProperty property in teg.Properties)
                {
                    if (property.Name == "groupName")
                        timedEventGroup.GroupName = property.Value;
                    if (property.Name == "groupID")
                        timedEventGroup.GroupId = Convert.ToInt32(property.Value);
                    if (property.Name == "beginImmediately")
                        timedEventGroup.BeginImmediately = Convert.ToBoolean(property.Value);
                    if (property.Name == "initialDelay")
                        timedEventGroup.InitialDelay = Convert.ToInt32(property.Value);
                }

                foreach (VtsObject tei in teg.Children)
                {
                    TimedEventInfo timedEventInfo = new TimedEventInfo();

                    foreach (VtsProperty property in tei.Properties)
                    {
                        if (property.Name == "eventName")
                            timedEventInfo.EventName = property.Value;
                        if (property.Name == "time")
                            timedEventInfo.Time = Convert.ToInt32(property.Value);
                    }

                    foreach (VtsObject et in tei.Children)
                    {
                        timedEventInfo.EventTargets.Add(ReadEventTarget(et));
                    }

                    timedEventGroup.TimedEventInfos.Add(timedEventInfo);
                }

                scenario.TimedEventGroups.Add(timedEventGroup);
            }
        }

        private static void ReadTriggerEvents(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject triggerEvents = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.TriggerEvents);

            if (triggerEvents == null)
            {
                // do we throw an error or not? force the trigger events block to be required?
                return;
            }

            foreach (VtsObject te in triggerEvents.Children)
            {
                TriggerEvent triggerEvent = new TriggerEvent();

                foreach (VtsProperty property in te.Properties)
                {
                    if (property.Name == "id")
                        triggerEvent.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "enabled")
                        triggerEvent.Enabled = Convert.ToBoolean(property.Value);
                    if (property.Name == "triggerType")
                        triggerEvent.TriggerType = property.Value;
                    if (property.Name == "conditional")
                        triggerEvent.Conditional = Convert.ToInt32(property.Value);
                    if (property.Name == "eventName")
                        triggerEvent.EventName = property.Value;
                    if (property.Name == "waypoint")
                        triggerEvent.Waypoint = Convert.ToInt32(property.Value);
                    if (property.Name == "radius")
                        triggerEvent.Radius = Convert.ToSingle(property.Value);
                    if (property.Name == "sphericalRadius")
                        triggerEvent.SphericalRadius = Convert.ToBoolean(property.Value);
                    if (property.Name == "triggerMode")
                        triggerEvent.TriggerMode = property.Value;
                    if (property.Name == "proxyMode")
                        triggerEvent.ProxyMode = property.Value;
                }

                triggerEvent.EventInfo = ReadEventInfo(te.Children[0]); // there should only ever be 1 EventInfo on a TriggerEvent

                scenario.TriggerEvents.Add(triggerEvent);
            }
        }

        private static void ReadObjectives(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject objectives = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Objectives);

            if (objectives == null)
            {
                // do we throw an error or not? force the objectives block to be required?
                return;
            }

            foreach (VtsObject obj in objectives.Children)
            {
                scenario.Objectives.Add(ReadObjective(obj));
            }
        }

        private static void ReadObjectvesOpFor(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject objectives = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.ObjectivesOpFor);

            if (objectives == null)
            {
                // do we throw an error or not? force the objectives op for block to be required?
                return;
            }

            foreach (VtsObject obj in objectives.Children)
            {
                scenario.ObjectivesOpFor.Add(ReadObjective(obj));
            }
        }

        private static void ReadStaticObjects(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject staticObjects = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.StaticObjects);

            if (staticObjects == null)
            {
                // do we throw an error or not? force the static objects block to be required?
                return;
            }

            foreach (VtsObject so in staticObjects.Children)
            {
                StaticObject staticObject = new StaticObject();

                foreach (VtsProperty property in so.Properties)
                {
                    if (property.Name == "prefabID")
                        staticObject.PrefabId = property.Value;
                    if (property.Name == "id")
                        staticObject.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "globalPos")
                        staticObject.GlobalPosition = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                    if (property.Name == "rotation")
                        staticObject.Rotation = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                }

                scenario.StaticObjects.Add(staticObject);
            }
        }

        private static void ReadConditionals(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject conditionals = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Conditionals);

            if (conditionals == null)
            {
                // do we throw an error or not? force the conditionals block to be required?
                return;
            }

            foreach (VtsObject con in conditionals.Children)
            {
                scenario.Conditionals.Add(ReadConditional(con));
            }
        }

        private static void ReadConditionalActions(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject conditionalActions = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.ConditionalActions);

            if (conditionalActions == null)
            {
                // do we throw an error or not? force the conditional actions block to be required?
                return;
            }

            foreach (VtsObject ca in conditionalActions.Children)
            {
                ConditionalAction conditionalAction = new ConditionalAction();

                foreach (VtsProperty property in ca.Properties)
                {
                    if (property.Name == "id")
                        conditionalAction.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "name")
                        conditionalAction.Name = property.Value;
                }

                Block baseBlock = new Block();
                VtsObject bb = ca.Children[0];

                foreach (VtsProperty property in bb.Properties)
                {
                    if (property.Name == "blockName")
                        baseBlock.BlockName = property.Value;
                    if (property.Name == "blockId")
                        baseBlock.BlockId = Convert.ToInt32(property.Value);
                }

                foreach (VtsObject baseBlockChild in bb.Children)
                {
                    if (baseBlockChild.Name == KeywordStrings.Conditional) // should be 1 conditional
                        baseBlock.Conditional = ReadConditional(baseBlockChild);
                    if (baseBlockChild.Name == KeywordStrings.Actions) // this is just an EventInfo object
                        baseBlock.Actions = ReadEventInfo(baseBlockChild);
                    if (baseBlockChild.Name == KeywordStrings.ElseIf) // this is another block object completely (there can be more than one)
                    {
                        Block elseIfBlock = new Block();

                        foreach (VtsProperty property in baseBlockChild.Properties)
                        {
                            if (property.Name == "blockName")
                                elseIfBlock.BlockName = property.Value;
                            if (property.Name == "blockId")
                                elseIfBlock.BlockId = Convert.ToInt32(property.Value);
                        }

                        foreach (VtsObject baseBlockGrandChild in baseBlockChild.Children)
                        {
                            if (baseBlockGrandChild.Name == KeywordStrings.Conditional) // should be 1 conditional
                                elseIfBlock.Conditional = ReadConditional(baseBlockGrandChild);
                            if (baseBlockGrandChild.Name == KeywordStrings.Actions) // this is just an EventInfo object
                                elseIfBlock.Actions = ReadEventInfo(baseBlockGrandChild);
                            if (baseBlockGrandChild.Name == KeywordStrings.ElseActions) // this is just an EventInfo object
                                elseIfBlock.ElseActions = ReadEventInfo(baseBlockGrandChild);
                        }

                        baseBlock.ElseIfBlocks.Add(elseIfBlock);
                    }
                    if (baseBlockChild.Name == KeywordStrings.ElseActions) // this is just an EventInfo object
                        baseBlock.ElseActions = ReadEventInfo(baseBlockChild);
                }

                conditionalAction.BaseBlock = baseBlock;

                scenario.ConditionalActions.Add(conditionalAction);
            }
        }

        private static void ReadEventSequences(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject eventSequences = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.EventSequences);

            if (eventSequences == null)
            {
                // do we throw an error or not? force the event sequences block to be required?
                return;
            }

            foreach (VtsObject es in eventSequences.Children)
            {
                Sequence sequence = new Sequence();

                foreach (VtsProperty property in es.Properties)
                {
                    if (property.Name == "id")
                        sequence.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "sequenceName")
                        sequence.SequenceName = property.Value;
                    if (property.Name == "startImmediately")
                        sequence.StartImmediately = Convert.ToBoolean(property.Value);
                }

                foreach (VtsObject e in es.Children)
                {
                    Event @event = new Event();

                    foreach (VtsProperty property in e.Properties)
                    {
                        if (property.Name == "conditional")
                            @event.Conditional = Convert.ToInt32(property.Value);
                        if (property.Name == "delay")
                            @event.Delay = Convert.ToInt32(property.Value);
                        if (property.Name == "nodeName")
                            @event.NodeName = property.Value;
                        if (property.Name == "exitConditional")
                            @event.ExitConditional = Convert.ToInt32(property.Value);
                    }

                    foreach (VtsObject ei in e.Children)
                    {
                        @event.EventInfo = ReadEventInfo(ei);
                    }

                    sequence.Events.Add(@event);
                }

                scenario.EventSequences.Add(sequence);
            }
        }

        private static void ReadBases(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject bases = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Bases);

            if (bases == null)
            {
                // do we throw an error or not? force the bases block to be required?
                return;
            }

            foreach (VtsObject b in bases.Children)
            {
                BaseInfo baseInfo = new BaseInfo();

                foreach (VtsProperty property in b.Properties)
                {
                    if (property.Name == "id")
                        baseInfo.Id = Convert.ToInt32(property.Value);
                    if (property.Name == "overrideBaseName")
                        baseInfo.OverrideBaseName = property.Value;
                    if (property.Name == "baseTeam")
                        baseInfo.BaseTeam = property.Value;
                }

                scenario.Bases.Add(baseInfo);
            }
        }

        private static void ReadGlobalValues(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject globalValues = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.GlobalValues);

            if (globalValues == null)
            {
                // do we throw an error or not? force the global values block to be required?
                return;
            }

            foreach (VtsObject gv in globalValues.Children)
            {
                GlobalValue globalValue = new GlobalValue();

                foreach (VtsProperty property in gv.Properties)
                {
                    string[] data = property.Value.Split(';');

                    globalValue.Index = Convert.ToInt32(data[0]);
                    globalValue.Name = data[1];
                    globalValue.Description = data[2];
                    globalValue.Value = Convert.ToInt32(data[3]);
                }

                scenario.GlobalValues.Add(globalValue);
            }
        }

        private static void ReadBriefingNotes(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject briefingNotes = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.Briefing);

            if (briefingNotes == null)
            {
                // do we throw an error or not? force the briefing block to be required?
                return;
            }

            foreach (VtsObject bn in briefingNotes.Children)
            {
                BriefingNote briefingNote = new BriefingNote();

                foreach (VtsProperty property in bn.Properties)
                {
                    if (property.Name == "text")
                        briefingNote.Text = property.Value;
                    if (property.Name == "imagePath")
                        briefingNote.ImagePath = property.Value;
                    if (property.Name == "audioClipPath")
                        briefingNote.AudioClipPath = property.Value;
                }

                scenario.BriefingNotes.Add(briefingNote);
            }
        }

        private static void ReadResourceManifest(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject resourceManifest = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.ResourceManifest);

            if (resourceManifest == null)
            {
                // do we throw an error or not? force the resource manifest block to be required?
                return;
            }

            foreach (VtsObject bn in resourceManifest.Children)
            {
                Resource resource = new Resource();

                foreach (VtsProperty property in bn.Properties)
                {
                    resource.Index = Convert.ToInt32(property.Name);
                    resource.Path = property.Value;
                }

                scenario.ResourceManifest.Add(resource);
            }
        }

        private static Conditional ReadConditional(VtsObject con)
        {
            Conditional conditional = new Conditional();

            foreach (VtsProperty property in con.Properties)
            {
                if (property.Name == "id")
                    conditional.Id = Convert.ToInt32(property.Value);
                if (property.Name == "outputNodePos")
                    conditional.OutputNodePosition = ReadThreePointValue(property.Value.Replace("(", "").Replace(")", ""));
                if (property.Name == "root")
                    conditional.Id = Convert.ToInt32(property.Value);
            }

            foreach (VtsObject child in con.Children)
            {
                Computation computation = new Computation();

                foreach (VtsProperty vtsProperty in child.Properties)
                {
                    if (vtsProperty.Name == "id")
                        computation.Id = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == "type")
                        computation.Type = vtsProperty.Value;
                    if (vtsProperty.Name == "uiPos")
                        computation.UiPosition = ReadThreePointValue(vtsProperty.Value.Replace("(", "").Replace(")", ""));
                    if (vtsProperty.Name == "unitGroup")
                        computation.UnitGroup = vtsProperty.Value;
                    if (vtsProperty.Name == "methodName")
                        computation.MethodName = vtsProperty.Value;
                    if (vtsProperty.Name == "methodParameters")
                        computation.MethodParameters = vtsProperty.Value;
                    if (vtsProperty.Name == "isNot")
                        computation.IsNot = Convert.ToBoolean(vtsProperty.Value);
                    if (vtsProperty.Name == "factors")
                        computation.Factors = vtsProperty.Value;
                    if (vtsProperty.Name == "gv")
                        computation.GlobalValue = vtsProperty.Value;
                    if (vtsProperty.Name == "comparison")
                        computation.Comparison = vtsProperty.Value;
                    if (vtsProperty.Name == "c_value")
                        computation.CValue = Convert.ToSingle(vtsProperty.Value);
                    if (vtsProperty.Name == "unitList")
                        computation.UnitList = vtsProperty.Value;
                    if (vtsProperty.Name == "objectReference")
                        computation.ObjectReference = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == "chance")
                        computation.Chance = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == "vehicleControl")
                        computation.VehicleControl = vtsProperty.Value;
                    if (vtsProperty.Name == "controlCondition")
                        computation.ControlCondition = vtsProperty.Value;
                    if (vtsProperty.Name == "controlValue")
                        computation.ControlValue = Convert.ToSingle(vtsProperty.Value);
                    if (vtsProperty.Name == "unit")
                        computation.Unit = Convert.ToInt32(vtsProperty.Value);
                }

                conditional.Computations.Add(computation);
            }

            return conditional;
        }

        private static EventInfo ReadEventInfo(VtsObject ei)
        {
            EventInfo eventInfo = new EventInfo();

            foreach (VtsProperty property in ei.Properties)
            {
                if (property.Name == "eventName")
                    eventInfo.EventName = property.Value;
            }

            foreach (VtsObject et in ei.Children)
            {
                eventInfo.EventTargets.Add(ReadEventTarget(et));
            }

            return eventInfo;
        }

        private static EventTarget ReadEventTarget(VtsObject et)
        {
            EventTarget eventTarget = new EventTarget();

            foreach (VtsProperty property in et.Properties)
            {
                if (property.Name == "targetType")
                    eventTarget.TargetType = property.Value;
                if (property.Name == "targetID")
                    eventTarget.TargetId = Convert.ToInt32(property.Value);
                if (property.Name == "eventName")
                    eventTarget.EventName = property.Value;
                if (property.Name == "methodName")
                    eventTarget.MethodName = property.Value;
            }

            foreach (VtsObject pi in et.Children)
            {
                ParamInfo paramInfo = new ParamInfo();

                foreach (VtsProperty property in pi.Properties)
                {
                    if (property.Name == "type")
                        paramInfo.Type = property.Value;
                    if (property.Name == "value")
                        paramInfo.Value = property.Value;
                    if (property.Name == "name")
                        paramInfo.Name = property.Value;
                }

                foreach (VtsObject pai in pi.Children)
                {
                    ParamAttrInfo paramAttrInfo = new ParamAttrInfo();

                    foreach (VtsProperty property in pai.Properties)
                    {
                        if (property.Name == "type")
                            paramAttrInfo.Type = property.Value;
                        if (property.Name == "data")
                            paramAttrInfo.Data = property.Value;
                    }

                    paramInfo.ParamAttrInfos.Add(paramAttrInfo);
                }

                eventTarget.ParamInfos.Add(paramInfo);
            }

            return eventTarget;
        }

        private static Objective ReadObjective(VtsObject obj)
        {
            Objective objective = new Objective();

            foreach (VtsProperty property in obj.Properties)
            {
                if (property.Name == "objectiveName")
                    objective.ObjectiveName = property.Value;
                if (property.Name == "objectiveInfo")
                    objective.ObjectiveInfo = property.Value;
                if (property.Name == "objectiveID")
                    objective.ObjectiveID = Convert.ToInt32(property.Value);
                if (property.Name == "orderID")
                    objective.OrderID = Convert.ToInt32(property.Value);
                if (property.Name == "required")
                    objective.Required = Convert.ToBoolean(property.Value);
                if (property.Name == "completionReward")
                    objective.CompletionReward = Convert.ToInt32(property.Value);
                if (property.Name == "waypoint")
                    objective.Waypoint = property.Value; // can't be an integer because of a value like unit:19
                if (property.Name == "autoSetWaypoint")
                    objective.AutoSetWaypoint = Convert.ToBoolean(property.Value);
                if (property.Name == "startMode")
                    objective.StartMode = property.Value;
                if (property.Name == "objectiveType")
                    objective.ObjectiveType = property.Value;
            }

            foreach (VtsObject vtsObject in obj.Children)
            {
                if (vtsObject.Name == KeywordStrings.StartEvent)
                    objective.StartEvent = ReadEventInfo(vtsObject.Children[0]);
                if (vtsObject.Name == KeywordStrings.FailEvent)
                    objective.FailEvent = ReadEventInfo(vtsObject.Children[0]);
                if (vtsObject.Name == KeywordStrings.CompleteEvent)
                    objective.CompleteEvent = ReadEventInfo(vtsObject.Children[0]);
                if (vtsObject.Name == KeywordStrings.Fields)
                {
                    ObjectiveFields objectiveFields = new ObjectiveFields();

                    foreach (VtsProperty property in vtsObject.Properties)
                    {
                        if (property.Name == "successConditional")
                            objectiveFields.SuccessConditional = Convert.ToInt32(property.Value);
                        if (property.Name == "failConditional")
                            objectiveFields.FailConditional = Convert.ToInt32(property.Value);
                        if (property.Name == "targets")
                            objectiveFields.Targets = property.Value;
                        if (property.Name == "minRequired")
                            objectiveFields.MinRequired = Convert.ToInt32(property.Value);
                        if (property.Name == "perUnitReward")
                            objectiveFields.PerUnitReward = Convert.ToInt32(property.Value);
                        if (property.Name == "fullCompleteBonus")
                            objectiveFields.FullCompletionBonus = Convert.ToInt32(property.Value);
                        if (property.Name == "unloadRadius")
                            objectiveFields.UnloadRadius = Convert.ToSingle(property.Value);
                        if (property.Name == "dropoffRallyPt")
                            objectiveFields.DropoffRallyPoint = Convert.ToInt32(property.Value);
                        if (property.Name == "triggerRadius")
                            objectiveFields.TriggerRadius = Convert.ToSingle(property.Value);
                        if (property.Name == "sphericalRadius")
                            objectiveFields.SphericalRadius = Convert.ToBoolean(property.Value);
                        if (property.Name == "targetUnit")
                            objectiveFields.TargetUnit = Convert.ToInt32(property.Value);
                        if (property.Name == "radius")
                            objectiveFields.Radius = Convert.ToSingle(property.Value);
                        if (property.Name == "fuelLevel")
                            objectiveFields.FuelLevel = Convert.ToSingle(property.Value);
                        if (property.Name == "completionMode")
                            objectiveFields.CompletionMode = property.Value;
                    }

                    objective.Fields = objectiveFields;
                }
            }

            return objective;
        }

        private static ThreePointValue ReadThreePointValue(string value)
        {
            string[] values = value.Split(',', StringSplitOptions.RemoveEmptyEntries);

            return new ThreePointValue
            {
                Point1 = Convert.ToSingle(values[0]),
                Point2 = Convert.ToSingle(values[1]),
                Point3 = Convert.ToSingle(values[2]),
            };
        }

        /// <summary>Reads the VTS file into a CustomScenario object.</summary>
        /// <param name="vtsFile">The VTS file to read.</param>
        /// <returns>The CustomScenario object containing the contents of the file or one with the HasError property set if a problem occurred.</returns>
        public static CustomScenario ReadVtsFile(string vtsFile)
        {
            CustomScenario scenario = new CustomScenario
            {
                File = vtsFile
            };

            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                VtsCustomScenarioObject cs = VtsReader.ReadVtsFile(vtsFile);

                ReadCustomScenarioProperties(scenario, cs);
                ReadUnits(scenario, cs);
                ReadPaths(scenario, cs);
                ReadWaypoints(scenario, cs);
                ReadUnitGroups(scenario, cs);
                ReadTimedEventGroups(scenario, cs);
                ReadTriggerEvents(scenario, cs);
                ReadObjectives(scenario, cs);
                ReadObjectvesOpFor(scenario, cs);
                ReadStaticObjects(scenario, cs);
                ReadConditionals(scenario, cs);
                ReadConditionalActions(scenario, cs);
                ReadEventSequences(scenario, cs);
                ReadBases(scenario, cs);
                ReadGlobalValues(scenario, cs);
                ReadBriefingNotes(scenario, cs);
                ReadResourceManifest(scenario, cs);

                sw.Stop();

                Debug.WriteLine($"CustomScenario read duration:{sw.Elapsed}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to read the VTS file.{Environment.NewLine}{ex}");

                return new CustomScenario
                {
                    File = vtsFile,
                    HasError = true
                };
            }

            return scenario;
        }

        private static void WriteCustomScenarioProperties(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            cs.Properties.Add(new VtsProperty { Name = "gameVersion", Value = scenario.GameVersion, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "campaignID", Value = scenario.CampaignId == null ? "" : scenario.CampaignId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "campaignOrderIdx", Value = scenario.CampaignOrderIndex.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "scenarioName", Value = scenario.ScenarioName, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "scenarioID", Value = scenario.ScenarioId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "scenarioDescription", Value = scenario.ScenarioDescription == null ? "" : scenario.ScenarioDescription, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "mapID", Value = scenario.MapId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "vehicle", Value = scenario.Vehicle, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "multiplayer", Value = scenario.Multiplayer ? "True" : "False", IndentDepth = 1 });

            if (!string.IsNullOrWhiteSpace(scenario.AllowedEquips) || scenario.AllowedEquips.Equals("none", StringComparison.OrdinalIgnoreCase))
                cs.Properties.Add(new VtsProperty { Name = "allowedEquips", Value = scenario.AllowedEquips, IndentDepth = 1 });

            cs.Properties.Add(new VtsProperty { Name = "forcedEquips", Value = string.IsNullOrWhiteSpace(scenario.ForcedEquips) ? ";;;;;;;;" : scenario.ForcedEquips, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "forceEquips", Value = scenario.ForceEquips ? "True" : "False", IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "normForcedFuel", Value = scenario.NormalForcedFuel.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "equipsConfigurable", Value = scenario.EquipsConfigurable ? "True" : "False", IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "baseBudget", Value = scenario.BaseBudget.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "isTraining", Value = scenario.IsTraining ? "True" : "False", IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "rtbWptID", Value = scenario.ReturnToBaseWaypointId == null ? "" : scenario.ReturnToBaseWaypointId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "refuelWptID", Value = scenario.RefuelWaypointId == null ? "" : scenario.RefuelWaypointId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "envName", Value = scenario.EnvironmentName, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "selectableEnv", Value = scenario.SelectableEnvironment ? "True" : "False", IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "qsMode", Value = scenario.QuickSaveMode, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = "qsLimit", Value = scenario.QuickSaveLimit.ToString(), IndentDepth = 1 });
        }

        private static void WriteUnits(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject units = new VtsObject { Name = KeywordStrings.Units, IndentDepth = 1 };

            foreach (UnitSpawner unitSpawner in scenario.Units)
            {
                VtsObject unit = new VtsObject { IndentDepth = 2 };
                unit.Properties.Add(new VtsProperty { Name = "unitName", Value = unitSpawner.UnitName, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "globalPosition", Value = unitSpawner.GlobalPosition.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "unitInstanceID", Value = unitSpawner.UnitInstanceId.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "unitID", Value = unitSpawner.UnitId, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "rotation", Value = unitSpawner.Rotation.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "spawnChance", Value = unitSpawner.SpawnChance.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "lastValidPlacement", Value = unitSpawner.LastValidPlacement.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "editorPlacementMode", Value = unitSpawner.EditorPlacementMode, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = "spawnFlags", Value = string.IsNullOrWhiteSpace(unitSpawner.SpawnFlags) ? "" : unitSpawner.SpawnFlags, IndentDepth = 3 });

                // process unit fields
                VtsObject unitFields = new VtsObject() { IndentDepth = 3 };

                List<string> propertiesForUnitFields = UnitFields.GetUnitFieldsForUnitType(unitSpawner.UnitId);
                
                foreach (string property in propertiesForUnitFields)
                {
                    if (property == "unitGroup")
                        unitFields.Properties.Add(new VtsProperty { Name = "unitGroup", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.UnitGroup) ? "null" : unitSpawner.UnitFields.UnitGroup, IndentDepth = 4 });
                    if (property == "defaultBehavior")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultBehavior", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultBehavior) ? "null" : unitSpawner.UnitFields.DefaultBehavior, IndentDepth = 4 });
                    if (property == "defaultWaypoint")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultWaypoint", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultWaypoint) ? "null" : unitSpawner.UnitFields.DefaultWaypoint, IndentDepth = 4 });
                    if (property== "defaultPath")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultPath", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultPath) ? "null" : unitSpawner.UnitFields.DefaultPath, IndentDepth = 4 });
                    if (property == "hullNumber")
                        unitFields.Properties.Add(new VtsProperty { Name = "hullNumber", Value = unitSpawner.UnitFields.HullNumber.ToString(), IndentDepth = 4 });
                    if (property == "engageEnemies")
                        unitFields.Properties.Add(new VtsProperty { Name = "engageEnemies", Value = unitSpawner.UnitFields.EngageEnemies ? "True" : "False", IndentDepth = 4 });
                    if (property == "detectionMode")
                        unitFields.Properties.Add(new VtsProperty { Name = "detectionMode", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DetectionMode) ? "null" : unitSpawner.UnitFields.DetectionMode, IndentDepth = 4 });
                    if (property == "spawnOnStart")
                        unitFields.Properties.Add(new VtsProperty { Name = "spawnOnStart", Value = unitSpawner.UnitFields.SpawnOnStart ? "True" : "False", IndentDepth = 4 });
                    if (property == "invincible")
                        unitFields.Properties.Add(new VtsProperty { Name = "invincible", Value = unitSpawner.UnitFields.Invincible ? "True" : "False", IndentDepth = 4 });
                    if (property == "carrierSpawns")
                        unitFields.Properties.Add(new VtsProperty { Name = "carrierSpawns", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.CarrierSpawns) ? "" : unitSpawner.UnitFields.CarrierSpawns, IndentDepth = 4 });
                    if (property == "radarUnits")
                        unitFields.Properties.Add(new VtsProperty { Name = "radarUnits", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.RadarUnits) ? "" : unitSpawner.UnitFields.RadarUnits, IndentDepth = 4 });
                    if (property == "allowReload")
                        unitFields.Properties.Add(new VtsProperty { Name = "allowReload", Value = unitSpawner.UnitFields.AllowReload ? "True" : "False", IndentDepth = 4 });
                    if (property == "reloadTime")
                        unitFields.Properties.Add(new VtsProperty { Name = "reloadTime", Value = unitSpawner.UnitFields.ReloadTime.ToString(), IndentDepth = 4 });
                    if (property == "combatTarget")
                        unitFields.Properties.Add(new VtsProperty { Name = "combatTarget", Value = unitSpawner.UnitFields.CombatTarget ? "True" : "False", IndentDepth = 4 });
                    if (property == "moveSpeed")
                        unitFields.Properties.Add(new VtsProperty { Name = "moveSpeed", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.MoveSpeed) ? "null" : unitSpawner.UnitFields.MoveSpeed, IndentDepth = 4 });
                    if (property == "behavior")
                        unitFields.Properties.Add(new VtsProperty { Name = "behavior", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Behavior) ? "null" : unitSpawner.UnitFields.Behavior, IndentDepth = 4 });
                    if (property == "waypoint")
                        unitFields.Properties.Add(new VtsProperty { Name = "waypoint", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Waypoint) ? "null" : unitSpawner.UnitFields.Waypoint, IndentDepth = 4 });
                    if (property == "voiceProfile")
                        unitFields.Properties.Add(new VtsProperty { Name = "voiceProfile", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.VoiceProfile) ? "null" : unitSpawner.UnitFields.VoiceProfile, IndentDepth = 4 });
                    if (property == "playerCommandsMode")
                        unitFields.Properties.Add(new VtsProperty { Name = "playerCommandsMode", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.PlayerCommandsMode) ? "null" : unitSpawner.UnitFields.PlayerCommandsMode, IndentDepth = 4 });
                    if (property == "initialSpeed")
                        unitFields.Properties.Add(new VtsProperty { Name = "initialSpeed", Value = unitSpawner.UnitFields.InitialSpeed.ToString(), IndentDepth = 4 });
                    if (property == "defaultNavSpeed")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultNavSpeed", Value = unitSpawner.UnitFields.DefaultNavSpeed.ToString(), IndentDepth = 4 });
                    if (property == "defaultOrbitPoint")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultOrbitPoint", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultOrbitPoint) ? "null" : unitSpawner.UnitFields.DefaultOrbitPoint, IndentDepth = 4 });
                    if (property == "orbitAltitude")
                        // this might need some kinf of special formatting for a decimal number, we shall see
                        unitFields.Properties.Add(new VtsProperty { Name = "orbitAltitude", Value = unitSpawner.UnitFields.OrbitAltitude.ToString(), IndentDepth = 4 });
                    if (property == "fuel")
                        unitFields.Properties.Add(new VtsProperty { Name = "fuel", Value = unitSpawner.UnitFields.Fuel.ToString(), IndentDepth = 4 });
                    if (property == "autoRefuel")
                        unitFields.Properties.Add(new VtsProperty { Name = "autoRefuel", Value = unitSpawner.UnitFields.AutoRefuel ? "True" : "False", IndentDepth = 4 });
                    if (property == "autoRTB")
                        unitFields.Properties.Add(new VtsProperty { Name = "autoRTB", Value = unitSpawner.UnitFields.AutoReturnToBase ? "True" : "False", IndentDepth = 4 });
                    if (property == "rtbDestination")
                        unitFields.Properties.Add(new VtsProperty { Name = "rtbDestination", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.ReturnToBaseDestination) ? "" : unitSpawner.UnitFields.ReturnToBaseDestination, IndentDepth = 4 });
                    if (property == "parkedStartMode")
                        unitFields.Properties.Add(new VtsProperty { Name = "parkedStartMode", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.ParkedStartMode) ? "null" : unitSpawner.UnitFields.ParkedStartMode, IndentDepth = 4 });
                    if (property == "equips")
                        // the default value here may need to become unit specific
                        unitFields.Properties.Add(new VtsProperty { Name = "equips", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Equips) ? ";;;;;;" : unitSpawner.UnitFields.Equips, IndentDepth = 4 });
                    if (property == "stopToEngage")
                        unitFields.Properties.Add(new VtsProperty { Name = "stopToEngage", Value = unitSpawner.UnitFields.StopToEngage ? "True" : "False", IndentDepth = 4 });
                    if (property == "startMode")
                        unitFields.Properties.Add(new VtsProperty { Name = "startMode", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.StartMode) ? "null" : unitSpawner.UnitFields.StartMode, IndentDepth = 4 });
                    if (property == "receiveFriendlyDamage")
                        unitFields.Properties.Add(new VtsProperty { Name = "receiveFriendlyDamage", Value = unitSpawner.UnitFields.ReceiveFriendlyDamage ? "True" : "False", IndentDepth = 4 });
                    if (property == "defaultRadarEnabled")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultRadarEnabled", Value = unitSpawner.UnitFields.DefaultRadarEnabled ? "True" : "False", IndentDepth = 4 });
                    if (property == "awacsVoiceProfile")
                        unitFields.Properties.Add(new VtsProperty { Name = "awacsVoiceProfile", Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.AwacsVoiceProfile) ? "null" : unitSpawner.UnitFields.AwacsVoiceProfile, IndentDepth = 4 });
                    if (property == "commsEnabled")
                        unitFields.Properties.Add(new VtsProperty { Name = "commsEnabled", Value = unitSpawner.UnitFields.CommsEnabled ? "True" : "False", IndentDepth = 4 });
                    if (property == "defaultShotsPerSalvo")
                        unitFields.Properties.Add(new VtsProperty { Name = "defaultShotsPerSalvo", Value = unitSpawner.UnitFields.DefaultShotsPerSalvo.ToString(), IndentDepth = 4 });
                    if (property == "rippleRate")
                        unitFields.Properties.Add(new VtsProperty { Name = "rippleRate", Value = unitSpawner.UnitFields.RippleRate.ToString(), IndentDepth = 4 });
                }

                unit.Children.Add(unitFields);

                units.Children.Add(unit);
            }

            cs.Children.Add(units);
        }

        private static void WritePaths(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteWaypoints(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteUnitGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteTimedEventGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteTriggerEvents(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteObjectives(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteObjectvesOpFor(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteStaticObjects(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteConditionals(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteConditionalActions(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteEventSequences(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteBases(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteGlobalValues(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteBriefingNotes(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void WriteResourceManifest(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        /// <summary>Writes the CustomScenario object to a VTS file. CustomScenario.File must be set.</summary>
        /// <param name="scenario">The CustomScenario object to write to the VTS file.</param>
        /// <returns>True if the VTS file was written, false if not (HasError will get set if an error occurred).</returns>
        /// <exception cref="ArgumentException">Occurs if the File property on the CustomScenario object is empty, null or consist of only white-space characters.</exception>
        public static bool WriteVtsFile(CustomScenario scenario)
        {
            try
            {
                if (scenario == null) return false;
                if (scenario.HasError) return false;
                if (string.IsNullOrWhiteSpace(scenario.File))
                    throw new ArgumentException("scenario File property cannot be empty, null or consist of white-space characters only.");

                Stopwatch sw = new Stopwatch();
                sw.Start();

                VtsCustomScenarioObject cs = new VtsCustomScenarioObject();

                WriteCustomScenarioProperties(scenario, cs);
                WriteUnits(scenario, cs);
                WritePaths(scenario, cs);
                WriteWaypoints(scenario, cs);
                WriteUnitGroups(scenario, cs);
                WriteTimedEventGroups(scenario, cs);
                WriteTriggerEvents(scenario, cs);
                WriteObjectives(scenario, cs);
                WriteObjectvesOpFor(scenario, cs);
                WriteStaticObjects(scenario, cs);
                WriteConditionals(scenario, cs);
                WriteConditionalActions(scenario, cs);
                WriteEventSequences(scenario, cs);
                WriteBases(scenario, cs);
                WriteGlobalValues(scenario, cs);
                WriteBriefingNotes(scenario, cs);
                WriteResourceManifest(scenario, cs);

                VtsWriter.WriteVtsFile(cs, scenario.File);

                sw.Stop();

                Debug.WriteLine($"CustomScenario write duration:{sw.Elapsed}");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to write the VTS file.{Environment.NewLine}{ex}");

                scenario.HasError = true;

                return false;
            }
        }

        #endregion
    }
}
