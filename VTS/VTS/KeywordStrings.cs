namespace VTS
{
    /// <summary>
    /// Contains all the keyword strings that are in the VTS file.
    /// </summary>
    /// <remarks>
    /// Not all keywords are used, specifically property keywords. Basically consider
    /// these the "tag" keywords the reader & writer use to identify objects in the 
    /// VTS file.
    /// </remarks>
    public class KeywordStrings
    {
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