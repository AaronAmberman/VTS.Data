namespace VTS
{
    /// <summary>Contains all the keyword strings that are in the VTS file.</summary>
    public class KeywordStrings
    {
        // misc / on more than one type
        public const string ConditionalProperty = "conditional";
        public const string Data = "data";
        public const string Enabled = "enabled";
        public const string EventName = "eventName";
        public const string EventTargetEventSequences = "Event_Sequences";
        public const string EventTargetTriggerEvents = "Trigger_Events";
        public const string EventTargetUnit = "Unit";
        public const string EventTargetUnitGroup = "UnitGroup";
        public const string False = "False";
        public const string Id = "id";
        public const string MapWaypoint = "map:";
        public const string MethodName = "methodName";
        public const string Name = "name";
        public const string None = "none";
        public const string Null = "null";
        public const string Radius = "radius";
        public const string Rotation = "rotation";
        public const string SccStaticObject = "SCCStaticObject";
        public const string SphericalRadius = "sphericalRadius";
        public const string StartMode = "startMode";
        public const string System = "System";
        public const string True = "True";
        public const string TriggerEventsProperty = "Trigger_Events";
        public const string Type = "type";
        public const string UnitGroup = "unitGroup";
        public const string UnitWaypoint = "unit:";
        public const string WaypointProperty = "waypoint";
        public const string Wpt = "wpt";
        public const string WptWaypoint = "wpt:";

        // properties on custom scenario
        public const string GameVersion = "gameVersion";
        public const string CampaignId = "campaignID";
        public const string CampaignOrderIdx = "campaignOrderIdx";
        public const string ScenarioName = "scenarioName";
        public const string ScenarioId = "scenarioID";
        public const string ScenarioDescription = "scenarioDescription";
        public const string MapId = "mapID";
        public const string Vehicle = "vehicle";
        public const string Multiplayer = "multiplayer";
        public const string AllowedEquips = "allowedEquips";
        public const string ForcedEquips = "forcedEquips";
        public const string ForceEquips = "forceEquips";
        public const string NormForcedFuel = "normForcedFuel";
        public const string EquipsConfigurable = "equipsConfigurable";
        public const string BaseBudget = "baseBudget";
        public const string IsTraining = "isTraining";
        public const string RtbWptId = "rtbWptID";
        public const string RefuelWptId = "refuelWptID";
        public const string InfiniteAmmo = "infiniteAmmo";
        public const string InfAmmoReloadDelay = "infAmmoReloadDelay";
        public const string FuelDrainMult = "fuelDrainMult";
        public const string EnvName = "envName";
        public const string SelectableEnv = "selectableEnv";
        public const string QsMode = "qsMode";
        public const string QsLimit = "qsLimit";

        // properties on unit spawner
        public const string UnitName = "unitName";
        public const string GlobalPosition = "globalPosition";
        public const string UnitInstanceId = "unitInstanceID";
        public const string UnitId = "unitID";
        public const string SpawnChance = "spawnChance";
        public const string LastValidPlacement = "lastValidPlacement";
        public const string EditorPlacementMode = "editorPlacementMode";
        public const string SpawnFlags = "spawnFlags";

        // properties on unit fields
        public const string DefaultBehavior = "defaultBehavior";
        public const string DefaultWaypoint = "defaultWaypoint";
        public const string DefaultPath = "defaultPath";
        public const string HullNumber = "hullNumber";
        public const string EngageEnemies = "engageEnemies";
        public const string DetectionMode = "detectionMode";
        public const string SpawnOnStart = "spawnOnStart";
        public const string Invincible = "invincible";
        public const string CarrierSpawns = "carrierSpawns";
        public const string RadarUnits = "radarUnits";
        public const string AllowReload = "allowReload";
        public const string ReloadTime = "reloadTime";
        public const string CombatTarget = "combatTarget";
        public const string MoveSpeed = "moveSpeed";
        public const string Behavior = "behavior";
        public const string VoiceProfile = "voiceProfile";
        public const string PlayerCommandsMode = "playerCommandsMode";
        public const string InitialSpeed = "initialSpeed";
        public const string DefaultNavSpeed = "defaultNavSpeed";
        public const string DefaultOrbitPoint = "defaultOrbitPoint";
        public const string OrbitAltitude = "orbitAltitude";
        public const string Fuel = "fuel";
        public const string AutoRefuel = "autoRefuel";
        public const string AutoRtb = "autoRTB";
        public const string RtbDestination = "rtbDestination";
        public const string ParkedStartMode = "parkedStartMode";
        public const string Equips = "equips";
        public const string StopToEngage = "stopToEngage";
        public const string ReceiveFriendlyDamage = "receiveFriendlyDamage";
        public const string DefaultRadarEnabled = "defaultRadarEnabled";
        public const string AwacsVoiceProfile = "awacsVoiceProfile";
        public const string CommsEnabled = "commsEnabled";
        public const string DefaultShotsPerSalvo = "defaultShotsPerSalvo";
        public const string RippleRate = "rippleRate";
        public const string Respawnable = "respawnable";

        // properties on a path
        public const string Loop = "loop";
        public const string Points = "points";
        public const string PathMode = "pathMode";

        // properties on a waypoint
        public const string GlobalPoint = "globalPoint";

        // unit groups
        public const string Alpha = "Alpha";
        public const string Bravo = "Bravo";
        public const string Charlie = "Charlie";
        public const string Delta = "Delta";
        public const string Echo = "Echo";
        public const string Foxtrot = "Foxtrot";
        public const string Golf = "Golf";
        public const string Hotel = "Hotel";
        public const string India = "India";
        public const string Juliet = "Juliet";
        public const string Kilo = "Kilo";
        public const string Lima = "Lima";
        public const string Mike = "Mike";
        public const string November = "November";
        public const string Oscar = "Oscar";
        public const string Papa = "Papa";
        public const string Quebec = "Quebec";
        public const string Romeo = "Romeo";
        public const string Sierra = "Sierra";
        public const string Tango = "Tango";
        public const string Uniform = "Uniform";
        public const string Victor = "Victor";
        public const string Whiskey = "Whiskey";
        public const string Xray = "Xray";
        public const string Yankee = "Yankee";
        public const string Zulu = "Zulu";

        // properties for unit group settings
        public const string SyncAltSpawns = "syncAltSpawns";
        public const string UnitGroupSettingsExtension = "_SETTINGS";

        // properties on timed event groups
        public const string GroupName = "groupName";
        public const string GroupId = "groupID";
        public const string BeginImmediately = "beginImmediately";
        public const string InitialDelay = "initialDelay";

        // properties on timed event infos        
        public const string Time = "time";

        // properties on trigger events
        public const string TriggerType = "triggerType";
        public const string TriggerMode = "triggerMode";
        public const string ProxyMode = "proxyMode";

        // properties on static objects
        public const string PrefabId = "prefabID";
        public const string GlobalPos = "globalPos";

        // properties on conditional actions
        public const string BlockName = "blockName";
        public const string BlockId = "blockId";

        // properties on sequences
        public const string SequenceName = "sequenceName";
        public const string StartImmediately = "startImmediately";
        public const string WhileLoop = "whileLoop";

        // properties on events
        public const string Delay = "delay";
        public const string NodeName = "nodeName";
        public const string ExitConditional = "exitConditional";

        // properties on base infos
        public const string OverrideBaseName = "overrideBaseName";
        public const string BaseTeam = "baseTeam";

        // properties on briefing notes
        public const string Text = "text";
        public const string ImagePath = "imagePath";
        public const string AudioClipPath = "audioClipPath";

        // properties on conditionals
        public const string OutputNodePos = "outputNodePos";
        public const string Root = "root";

        // properties on computations
        public const string UiPos = "uiPos";
        public const string MethodParameters = "methodParameters";
        public const string IsNot = "isNot";
        public const string Factors = "factors";
        public const string Comparison = "comparison";
        public const string C_Value = "c_value";
        public const string UnitList = "unitList";
        public const string ObjectReference = "objectReference";
        public const string Chance = "chance";
        public const string VehicleControl = "vehicleControl";
        public const string ControlCondition = "controlCondition";
        public const string ControlValue = "controlValue";
        public const string Unit = "unit";

        // properties on event targets
        public const string TargetType = "targetType";
        public const string TargetId = "targetID";

        // properties on param infos
        public const string Value = "value";

        // properties on objectives
        public const string ObjectiveName = "objectiveName";
        public const string ObjectiveInfo = "objectiveInfo";
        public const string ObjectiveId = "objectiveID";
        public const string ObjectiveType = "objectiveType";
        public const string OrderId = "orderID";
        public const string Required = "required";
        public const string CompletionReward = "completionReward";
        public const string AutoSetWaypoint = "autoSetWaypoint";
        public const string PreReqObjectives = "preReqObjectives";

        // properties on objective fields
        public const string SuccessConditional = "successConditional";
        public const string FailConditional = "failConditional";
        public const string Targets = "targets";
        public const string MinRequired = "minRequired";
        public const string PerUnitReward = "perUnitReward";
        public const string FullCompleteBonus = "fullCompleteBonus";
        public const string UnloadRadius = "unloadRadius";
        public const string DropoffRallyPt = "dropoffRallyPt";
        public const string TriggerRadius = "triggerRadius";
        public const string TargetUnit = "targetUnit";
        public const string FuelLevel = "fuelLevel";
        public const string CompletionMode = "completionMode";
        public const string Target = "target";

        // player aircraft
        public const string Av42C = "AV-42C";
        public const string Fa26B = "F/A-26B";
        public const string F45A = "F-45A";

        // aircraft that can have edit loadouts
        public const string AV42CAi = "AV-42CAI";
        public const string F45AAi = "F-45A AI";
        public const string FA26BAi = "FA-26B AI";
        public const string ABomberAi = "ABomberAI";
        public const string MQ31 = "MQ-31";
        public const string AiUCAV = "AIUCAV";
        public const string ASF30 = "ASF-30";
        public const string ASF33 = "ASF-33";
        public const string ASF58 = "ASF-58";
        public const string EBomberAi = "EBomberAI";
        public const string Gav25 = "GAV-25";

        // ships that can have carrier spawns
        public const string EscortCruiser = "EscortCruiser"; // 1 unit
        public const string AlliedAaShip = "AlliedAAShip"; // 6 units
        public const string AlliedCarrier = "AlliedCarrier"; // 9 units
        public const string EnemyCarrier = "EnemyCarrier"; // 10 units

        // used by Raw and Abstraction namespaces for VTS object construction and recognition
        public const string Actions = "ACTIONS";
        public const string Allied = "ALLIED";
        public const string BaseBlock = "BASE_BLOCK";
        public const string BaseInfo = "BaseInfo";
        public const string BriefingNote = "BRIEFING_NOTE";
        public const string Comp = "COMP";
        public const string CompleteEvent = "completeEvent";
        public const string Conditional = "CONDITIONAL";
        public const string ConditionalAction = "ConditionalAction";
        public const string CustomScenario = "CustomScenario";
        public const string Bases = "BASES";
        public const string Briefing = "Briefing";
        public const string Conditionals = "Conditionals";
        public const string ConditionalActions = "ConditionalActions";
        public const string ElseActions = "ELSE_ACTIONS";
        public const string ElseIf = "ELSE_IF";
        public const string Enemy = "ENEMY";
        public const string Event = "EVENT";
        public const string EventInfo = "EventInfo";
        public const string EventSequences = "EventSequences";
        public const string EventTarget = "EventTarget";
        public const string FailEvent = "failEvent";
        public const string Fields = "fields";
        public const string GlobalValue = "gv";
        public const string GlobalValues = "GlobalValues";
        public const string Objective = "Objective";
        public const string Objectives = "OBJECTIVES";
        public const string ObjectivesOpFor = "OBJECTIVES_OPFOR";
        public const string ParamAttrInfo = "ParamAttrInfo";
        public const string ParamInfo = "ParamInfo";
        public const string Path = "PATH";
        public const string Paths = "PATHS";
        public const string ResourceManifest = "ResourceManifest";
        public const string SettingsAlpha = "Alpha_SETTINGS";
        public const string SettingsBravo = "Bravo_SETTINGS";
        public const string SettingsCharlie = "Charlie_SETTINGS";
        public const string SettingsDelta = "Delta_SETTINGS";
        public const string SettingsEcho = "Echo_SETTINGS";
        public const string SettingsFoxtrot = "Foxtrot_SETTINGS";
        public const string SettingsGolf = "Golf_SETTINGS";
        public const string SettingsHotel = "Hotel_SETTINGS";
        public const string SettingsIndia = "India_SETTINGS";
        public const string SettingsJuliet = "Juliet_SETTINGS";
        public const string SettingsKilo = "Kilo_SETTINGS";
        public const string SettingsLima = "Lima_SETTINGS";
        public const string SettingsMike = "Mike_SETTINGS";
        public const string SettingsNovember = "November_SETTINGS";
        public const string SettingsOscar = "Oscar_SETTINGS";
        public const string SettingsPapa = "Papa_SETTINGS";
        public const string SettingsQuebec = "Quebec_SETTINGS";
        public const string SettingsRomeo = "Romeo_SETTINGS";
        public const string SettingsSierra = "Sierra_SETTINGS";
        public const string SettingsTango = "Tango_SETTINGS";
        public const string SettingsUniform = "Uniform_SETTINGS";
        public const string SettingsVictor = "Victor_SETTINGS";
        public const string SettingsWhiskey = "Whiskey_SETTINGS";
        public const string SettingsXray = "Xray_SETTINGS";
        public const string SettingsYankee = "Yankee_SETTINGS";
        public const string SettingsZulu = "Zulu_SETTINGS";
        public const string StaticObjects = "StaticObjects";
        public const string Sequence = "SEQUENCE";
        public const string StartEvent = "startEvent";
        public const string StaticObject = "StaticObject";
        public const string TimedEventGroup = "TimedEventGroup";
        public const string TimedEventGroups = "TimedEventGroups";
        public const string TimedEventInfo = "TimedEventInfo";
        public const string TriggerEvent = "TriggerEvent";
        public const string TriggerEvents = "TRIGGER_EVENTS";
        public const string UnitFields = "UnitFields";
        public const string UnitGroups = "UNITGROUPS";
        public const string Units = "UNITS";
        public const string UnitSpawner = "UnitSpawner";
        public const string Waypoint = "WAYPOINT";
        public const string Waypoints = "WAYPOINTS";

        // tells the VtsReader what to recognize as an object type that has children and/or properties that needs to be read recursively
        public static IReadOnlyList<string> ObjectStrings => new List<string>
        {
            Actions, Allied, BaseBlock, BaseInfo, Bases, Briefing, BriefingNote, Comp, CompleteEvent,
            Conditionals, Conditional, ConditionalActions, ConditionalAction, ElseActions, ElseIf, 
            Enemy, Event, EventInfo, EventSequences, EventTarget, FailEvent, Fields, GlobalValues, 
            GlobalValue, ParamAttrInfo, Objectives, ObjectivesOpFor, Objective, ParamInfo, Paths, Path,
            ResourceManifest, Sequence, SettingsAlpha, SettingsBravo, SettingsCharlie, SettingsDelta, 
            SettingsEcho, SettingsFoxtrot, SettingsGolf, SettingsHotel, SettingsIndia, SettingsJuliet, 
            SettingsKilo, SettingsLima, SettingsMike, SettingsNovember, SettingsOscar, SettingsPapa, 
            SettingsQuebec, SettingsRomeo, SettingsSierra, SettingsTango, SettingsUniform, SettingsVictor, 
            SettingsWhiskey, SettingsXray, SettingsYankee, SettingsZulu, StartEvent, StaticObjects, 
            StaticObject, TimedEventGroups, TimedEventGroup, TimedEventInfo, TriggerEvents, TriggerEvent,
            UnitGroups, Units, UnitSpawner, UnitFields, Waypoints, Waypoint
        };
    }
}