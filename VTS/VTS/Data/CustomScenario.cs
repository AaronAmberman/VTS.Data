﻿using System.Diagnostics;
using VTS.Collections;
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
        public string ForceEquips { get; set; }
        public bool ForcedEquips { get; set; }
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
                    scenario.ForcedEquips = Convert.ToBoolean(property.Value);
                if (property.Name == "forceEquips")
                    scenario.ForceEquips = property.Value;
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
                    {
                        string[] values = property.Value.Replace("(", "").Replace(")", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        unitSpawner.GlobalPosition = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(values[0]),
                            Point2 = Convert.ToSingle(values[1]),
                            Point3 = Convert.ToSingle(values[2]),
                        };
                    }
                    if (property.Name == "unitInstanceID")
                        unitSpawner.UnitInstanceId = Convert.ToInt32(property.Value);
                    if (property.Name == "unitID")
                        unitSpawner.UnitId = property.Value;
                    if (property.Name == "rotation")
                    {
                        string[] values = property.Value.Replace("(", "").Replace(")", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        unitSpawner.Rotation = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(values[0]),
                            Point2 = Convert.ToSingle(values[1]),
                            Point3 = Convert.ToSingle(values[2]),
                        };
                    }
                    if (property.Name == "spawnChance")
                        unitSpawner.SpawnChance = Convert.ToInt32(property.Value);
                    if (property.Name == "lastValidPlacement")
                    {
                        string[] values = property.Value.Replace("(", "").Replace(")", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        unitSpawner.LastValidPlacement = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(values[0]),
                            Point2 = Convert.ToSingle(values[1]),
                            Point3 = Convert.ToSingle(values[2]),
                        };
                    }
                    if (property.Name == "spawnFlags")
                        unitSpawner.SpawnFlags = property.Value;

                    // every unit will have one child object, the unit fields object
                    UnitFields uf = new UnitFields();
                    VtsObject unitFields = unit.Children[0];

                    foreach (VtsProperty ufProperty in unitFields.Properties)
                    {
                        if (property.Name == "unitGroup")
                            uf.UnitGroup = property.Value;
                        if (property.Name == "defaultBehavior")
                            uf.DefaultBehavior = property.Value;
                        if (property.Name == "defaultWaypoint")
                            uf.DefaultWaypoint = property.Value;
                        if (property.Name == "defaultPath")
                            uf.DefaultPath = property.Value;
                        if (property.Name == "hullNumber")
                            uf.HullNumber = Convert.ToInt32(property.Value);
                        if (property.Name == "engageEnemies")
                            uf.EngageEnemies = Convert.ToBoolean(property.Value);
                        if (property.Name == "detectionMode")
                            uf.DetectionMode = property.Value;
                        if (property.Name == "spawnOnStart")
                            uf.SpawnOnStart = Convert.ToBoolean(property.Value);
                        if (property.Name == "invincible")
                            uf.Invincible = Convert.ToBoolean(property.Value);
                        if (property.Name == "carrierSpawns")
                            uf.CarrierSpawns = property.Value;
                        if (property.Name == "radarUnits")
                            uf.RadarUnits = property.Value;
                        if (property.Name == "allowReload")
                            uf.AllowReload = Convert.ToBoolean(property.Value);
                        if (property.Name == "reloadTime")
                            uf.ReloadTime = Convert.ToInt32(property.Value);
                        if (property.Name == "combatTarget")
                            uf.CombatTarget = Convert.ToBoolean(property.Value);
                        if (property.Name == "moveSpeed")
                            uf.MoveSpeed = property.Value;
                        if (property.Name == "behavior")
                            uf.Behavior = property.Value;
                        if (property.Name == "waypoint")
                            uf.Waypoint = property.Value;
                        if (property.Name == "voiceProfile")
                            uf.VoiceProfile = property.Value;
                        if (property.Name == "playerCommandsMode")
                            uf.PlayerCommandsMode = property.Value;
                        if (property.Name == "initialSpeed")
                            uf.InitialSpeed = Convert.ToInt32(property.Value);
                        if (property.Name == "defaultNavSpeed")
                            uf.DefaultNavSpeed = Convert.ToInt32(property.Value);
                        if (property.Name == "defaultOrbitPoint")
                            uf.DefaultOrbitPoint = property.Value;
                        if (property.Name == "orbitAltitude")
                            uf.OrbitAltitude = Convert.ToInt32(property.Value);
                        if (property.Name == "fuel")
                            uf.Fuel = Convert.ToInt32(property.Value);
                        if (property.Name == "autoRefuel")
                            uf.AutoRefuel = Convert.ToBoolean(property.Value);
                        if (property.Name == "autoRTB")
                            uf.AutoReturnToBase = Convert.ToBoolean(property.Value);
                        if (property.Name == "rtbDestination")
                            uf.ReturnToBaseDestination = property.Value;
                        if (property.Name == "parkedStartMode")
                            uf.ParkedStartMode = property.Value;
                        if (property.Name == "equips")
                            uf.Equips = property.Value;
                        if (property.Name == "stopToEngage")
                            uf.StopToEngage = Convert.ToBoolean(property.Value);
                        if (property.Name == "startMode")
                            uf.StartMode = property.Value;
                        if (property.Name == "receiveFriendlyDamage")
                            uf.ReceiveFriendlyDamage = Convert.ToBoolean(property.Value);
                        if (property.Name == "defaultRadarEnabled")
                            uf.DefaultRadarEnabled = Convert.ToBoolean(property.Value);
                        if (property.Name == "awacsVoiceProfile")
                            uf.AwacsVoiceProfile = property.Value;
                        if (property.Name == "commsEnabled")
                            uf.CommsEnabled = Convert.ToBoolean(property.Value);
                        if (property.Name == "defaultShotsPerSalvo")
                            uf.DefaultShotsPerSalvo =Convert.ToInt32(property.Value);
                        if (property.Name == "rippleRate")
                            uf.RippleRate = Convert.ToInt32(property.Value);
                    }

                    unitSpawner.UnitFields = uf;
                }

                scenario.Units.Add(unitSpawner);
            }
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
                        string[] points = property.Value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        List<ThreePointValue> pointValues = new List<ThreePointValue>();

                        foreach (string point in points)
                        {
                            string[] values = point.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            ThreePointValue threePointValue = new ThreePointValue
                            {
                                Point1 = Convert.ToSingle(values[0]),
                                Point2 = Convert.ToSingle(values[1]),
                                Point3 = Convert.ToSingle(values[2])
                            };

                            pointValues.Add(threePointValue);
                        }
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
                    {
                        string[] values = property.Value.Replace("(", "").Replace(")", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        ThreePointValue threePointValue = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(values[0]),
                            Point2 = Convert.ToSingle(values[1]),
                            Point3 = Convert.ToSingle(values[2])
                        };

                        w.GlobalPoint = threePointValue;
                    }
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

                        timedEventInfo.EventTargets.Add(eventTarget);
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

                VtsObject ei = te.Children[0]; // there should only ever be 1 EventInfo on a TriggerEvent
                EventInfo eventInfo = new EventInfo();

                foreach (VtsProperty property in ei.Properties)
                {
                    if (property.Name == "eventName")
                        eventInfo.EventName = property.Value;
                }

                foreach (VtsObject et in ei.Children)
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

                    eventInfo.EventTargets.Add(eventTarget);
                }

                triggerEvent.EventInfo = eventInfo;

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
                Objective objective = new Objective();

                foreach (VtsProperty property in obj.Properties)
                {
                    if (property.Name == "objectiveName")
                        objective.ObjectiveName = property.Value;
                    if (property.Name == "objectiveInfo")
                        objective.ObjectiveInfo = property.Value;
                    if (property.Name == "objectiveID")
                        objective.ObjectiveID = property.Value;
                    if (property.Name == "orderID")
                        objective.OrderID = property.Value;
                    if (property.Name == "required")
                        objective.Required = property.Value;
                    if (property.Name == "completionReward")
                        objective.CompletionReward = property.Value;
                    if (property.Name == "waypoint")
                        objective.Waypoint = property.Value;
                    if (property.Name == "autoSetWaypoint")
                        objective.AutoSetWaypoint = property.Value;
                    if (property.Name == "startMode")
                        objective.StartMode = property.Value;
                    if (property.Name == "objectiveType")
                        objective.ObjectiveType = property.Value;
                }

                foreach (VtsObject vtsObject in obj.Children)
                {
                    if (vtsObject.Name == KeywordStrings.StartEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.StartEvent = eventInfo;
                    }
                    if (vtsObject.Name == KeywordStrings.FailEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.FailEvent = eventInfo;
                    }
                    if (vtsObject.Name == KeywordStrings.CompleteEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.CompleteEvent = eventInfo;
                    }
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

                scenario.Objectives.Add(objective);
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
                Objective objective = new Objective();

                foreach (VtsProperty property in obj.Properties)
                {
                    if (property.Name == "objectiveName")
                        objective.ObjectiveName = property.Value;
                    if (property.Name == "objectiveInfo")
                        objective.ObjectiveInfo = property.Value;
                    if (property.Name == "objectiveID")
                        objective.ObjectiveID = property.Value;
                    if (property.Name == "orderID")
                        objective.OrderID = property.Value;
                    if (property.Name == "required")
                        objective.Required = property.Value;
                    if (property.Name == "completionReward")
                        objective.CompletionReward = property.Value;
                    if (property.Name == "waypoint")
                        objective.Waypoint = property.Value;
                    if (property.Name == "autoSetWaypoint")
                        objective.AutoSetWaypoint = property.Value;
                    if (property.Name == "startMode")
                        objective.StartMode = property.Value;
                    if (property.Name == "objectiveType")
                        objective.ObjectiveType = property.Value;
                }

                foreach (VtsObject vtsObject in obj.Children)
                {
                    if (vtsObject.Name == KeywordStrings.StartEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.StartEvent = eventInfo;
                    }
                    if (vtsObject.Name == KeywordStrings.FailEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.FailEvent = eventInfo;
                    }
                    if (vtsObject.Name == KeywordStrings.CompleteEvent)
                    {
                        EventInfo eventInfo = new EventInfo();
                        VtsObject se = vtsObject.Children[0]; // should be the only EventInfo inside the event

                        foreach (VtsProperty property in se.Properties)
                        {
                            if (property.Name == "eventName")
                                eventInfo.EventName = property.Value;
                        }

                        foreach (VtsObject et in se.Children)
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
                        }

                        objective.CompleteEvent = eventInfo;
                    }
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

                scenario.ObjectivesOpFor.Add(objective);
            }
        }

        private static void ReadStaticObjects(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject staticObjects = cs.Children.FirstOrDefault(c => c.Name == KeywordStrings.ObjectivesOpFor);

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
                    {
                        string[] temp = property.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        ThreePointValue threePointValue = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(temp[0]),
                            Point2 = Convert.ToSingle(temp[1]),
                            Point3 = Convert.ToSingle(temp[2])
                        };

                        staticObject.GlobalPosition = threePointValue;
                    }
                    if (property.Name == "rotation")
                    {
                        string[] temp = property.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        ThreePointValue threePointValue = new ThreePointValue
                        {
                            Point1 = Convert.ToSingle(temp[0]),
                            Point2 = Convert.ToSingle(temp[1]),
                            Point3 = Convert.ToSingle(temp[2])
                        };

                        staticObject.Rotation = threePointValue;
                    }
                }

                scenario.StaticObjects.Add(staticObject);
            }
        }

        private static void ReadConditionals(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadConditionalActions(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadEventSequences(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadBases(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadGlobalValues(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadBriefingNotes(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

        }

        private static void ReadResourceManifest(CustomScenario scenario, VtsCustomScenarioObject cs)
        {

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
