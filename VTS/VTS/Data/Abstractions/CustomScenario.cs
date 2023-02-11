using System.Collections;
using System.Diagnostics;
using VTS.Collections;
using VTS.Data.Diagnostics;
using VTS.Data.Raw;
using VTS.File;

namespace VTS.Data.Abstractions
{
    /// <summary>A managed wrapper for the VTS file.</summary>
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenario : ICloneable
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
        public float FuelDrainMultiplier { get; set; }
        public string GameVersion { get; set; }
        public bool InfiniteAmmo { get; set; }
        public float InfiniteAmmoReloadDelay { get; set; }
        public bool IsTraining { get; set; }
        public string MapId { get; set; }
        public bool Multiplayer { get; set; }
        public float NormalForcedFuel { get; set; }
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

        private static void ReadCustomScenarioProperties(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            foreach (VtsProperty property in cs.Properties)
            {
                if (property.Name == KeywordStrings.GameVersion)
                    scenario.GameVersion = property.Value;
                if (property.Name == KeywordStrings.CampaignId)
                    scenario.CampaignId = property.Value;
                if (property.Name == KeywordStrings.CampaignOrderIdx)
                    scenario.CampaignOrderIndex = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.ScenarioName)
                    scenario.ScenarioName = property.Value;
                if (property.Name == KeywordStrings.ScenarioId)
                    scenario.ScenarioId = property.Value;
                if (property.Name == KeywordStrings.ScenarioDescription)
                    scenario.ScenarioDescription = property.Value;
                if (property.Name == KeywordStrings.MapId)
                    scenario.MapId = property.Value;
                if (property.Name == KeywordStrings.Vehicle)
                    scenario.Vehicle = property.Value;
                if (property.Name == KeywordStrings.Multiplayer)
                    scenario.Multiplayer = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.AllowedEquips)
                    scenario.AllowedEquips = property.Value;
                if (property.Name == KeywordStrings.ForcedEquips)
                    scenario.ForcedEquips = property.Value;
                if (property.Name == KeywordStrings.ForceEquips)
                    scenario.ForceEquips = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.NormForcedFuel)
                    scenario.NormalForcedFuel = Convert.ToSingle(property.Value);
                if (property.Name == KeywordStrings.EquipsConfigurable)
                    scenario.EquipsConfigurable = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.BaseBudget)
                    scenario.BaseBudget = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.IsTraining)
                    scenario.IsTraining = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.RtbWptId)
                    scenario.ReturnToBaseWaypointId = property.Value;
                if (property.Name == KeywordStrings.RefuelWptId)
                    scenario.RefuelWaypointId = property.Value;
                if (property.Name == KeywordStrings.InfiniteAmmo)
                    scenario.InfiniteAmmo = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.InfAmmoReloadDelay)
                    scenario.InfiniteAmmoReloadDelay = Convert.ToSingle(property.Value);
                if (property.Name == KeywordStrings.FuelDrainMult)
                    scenario.FuelDrainMultiplier = Convert.ToSingle(property.Value);
                if (property.Name == KeywordStrings.EnvName)
                    scenario.EnvironmentName = property.Value;
                if (property.Name == KeywordStrings.SelectableEnv)
                    scenario.SelectableEnvironment = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.QsMode)
                    scenario.QuickSaveMode = property.Value;
                if (property.Name == KeywordStrings.QsLimit)
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
                    if (property.Name == KeywordStrings.UnitName)
                        unitSpawner.UnitName = property.Value;
                    if (property.Name == KeywordStrings.GlobalPosition)
                        unitSpawner.GlobalPosition = property.Value;
                    if (property.Name == KeywordStrings.UnitInstanceId)
                        unitSpawner.UnitInstanceId = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.UnitId)
                        unitSpawner.UnitId = property.Value;
                    if (property.Name == KeywordStrings.Rotation)
                        unitSpawner.Rotation = property.Value;
                    if (property.Name == KeywordStrings.SpawnChance)
                        unitSpawner.SpawnChance = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.LastValidPlacement)
                        unitSpawner.LastValidPlacement = property.Value;
                    if (property.Name == KeywordStrings.EditorPlacementMode)
                        unitSpawner.EditorPlacementMode = property.Value;
                    if (property.Name == KeywordStrings.SpawnFlags)
                        unitSpawner.SpawnFlags = property.Value;
                }

                // every unit will have one child object, the unit fields object
                UnitFields uf = new UnitFields();
                VtsObject unitFields = unit.Children[0];

                foreach (VtsProperty ufProperty in unitFields.Properties)
                {
                    if (ufProperty.Name == KeywordStrings.UnitGroup)
                        uf.UnitGroup = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.DefaultBehavior)
                        uf.DefaultBehavior = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.DefaultWaypoint)
                        uf.DefaultWaypoint = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.DefaultPath)
                        uf.DefaultPath = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.HullNumber)
                        uf.HullNumber = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.EngageEnemies)
                        uf.EngageEnemies = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.DetectionMode)
                        uf.DetectionMode = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.SpawnOnStart)
                        uf.SpawnOnStart = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.Invincible)
                        uf.Invincible = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.CarrierSpawns)
                        uf.CarrierSpawns = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.RadarUnits)
                        uf.RadarUnits = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.AllowReload)
                        uf.AllowReload = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.ReloadTime)
                        uf.ReloadTime = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.CombatTarget)
                        uf.CombatTarget = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.MoveSpeed)
                        uf.MoveSpeed = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.Behavior)
                        uf.Behavior = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.WaypointProperty)
                        uf.Waypoint = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.VoiceProfile)
                        uf.VoiceProfile = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.PlayerCommandsMode)
                        uf.PlayerCommandsMode = ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.InitialSpeed)
                        uf.InitialSpeed = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.DefaultNavSpeed)
                        uf.DefaultNavSpeed = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.DefaultOrbitPoint)
                        uf.DefaultOrbitPoint = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.OrbitAltitude)
                        uf.OrbitAltitude = Convert.ToSingle(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.Fuel)
                        uf.Fuel = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.AutoRefuel)
                        uf.AutoRefuel = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.AutoRtb)
                        uf.AutoReturnToBase = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.RtbDestination)
                        uf.ReturnToBaseDestination = ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.ParkedStartMode)
                        uf.ParkedStartMode = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.Equips)
                        uf.Equips = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.StopToEngage)
                        uf.StopToEngage = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.StartMode)
                        uf.StartMode = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.ReceiveFriendlyDamage)
                        uf.ReceiveFriendlyDamage = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.DefaultRadarEnabled)
                        uf.DefaultRadarEnabled = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.AwacsVoiceProfile)
                        uf.AwacsVoiceProfile = ufProperty.Value == KeywordStrings.Null ? null : ufProperty.Value;
                    if (ufProperty.Name == KeywordStrings.CommsEnabled)
                        uf.CommsEnabled = Convert.ToBoolean(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.DefaultShotsPerSalvo)
                        uf.DefaultShotsPerSalvo = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.RippleRate)
                        uf.RippleRate = Convert.ToInt32(ufProperty.Value);
                    if (ufProperty.Name == KeywordStrings.Respawnable)
                        uf.Respawnable = Convert.ToBoolean(ufProperty.Value);
                }

                unitSpawner.UnitFields = uf;

                scenario.Units.Add(unitSpawner);

                if (DiagnosticOptions.OutputUnitFieldsGroups)
                    VtsDiagnosticHelper.UnitAndFields.Add(new Tuple<VtsObject, VtsObject>(unit, unitFields));
            }

            if (DiagnosticOptions.OutputUnitFieldsGroups)
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
                    if (property.Name == KeywordStrings.Id)
                        p.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.Name)
                        p.Name = property.Value;
                    if (property.Name == KeywordStrings.Loop)
                        p.Loop = Convert.ToBoolean(property.Value);
                    if (property.Name == KeywordStrings.Points)
                        p.Points = property.Value;
                    if (property.Name == KeywordStrings.PathMode)
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
                    if (property.Name == KeywordStrings.Id)
                        w.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.Name)
                        w.Name = property.Value;
                    if (property.Name == KeywordStrings.GlobalPoint)
                        w.GlobalPoint = property.Value;
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
                    if (property.Name == KeywordStrings.Alpha)
                        unitGroup.Alpha = property.Value;
                    if (property.Name == KeywordStrings.Bravo)
                        unitGroup.Bravo = property.Value;
                    if (property.Name == KeywordStrings.Charlie)
                        unitGroup.Charlie = property.Value;
                    if (property.Name == KeywordStrings.Delta)
                        unitGroup.Delta = property.Value;
                    if (property.Name == KeywordStrings.Echo)
                        unitGroup.Echo = property.Value;
                    if (property.Name == KeywordStrings.Foxtrot)
                        unitGroup.Foxtrot = property.Value;
                    if (property.Name == KeywordStrings.Golf)
                        unitGroup.Golf = property.Value;
                    if (property.Name == KeywordStrings.Hotel)
                        unitGroup.Hotel = property.Value;
                    if (property.Name == KeywordStrings.India)
                        unitGroup.India = property.Value;
                    if (property.Name == KeywordStrings.Juliet)
                        unitGroup.Juliet = property.Value;
                    if (property.Name == KeywordStrings.Kilo)
                        unitGroup.Kilo = property.Value;
                    if (property.Name == KeywordStrings.Lima)
                        unitGroup.Lima = property.Value;
                    if (property.Name == KeywordStrings.Mike)
                        unitGroup.Mike = property.Value;
                    if (property.Name == KeywordStrings.November)
                        unitGroup.November = property.Value;
                    if (property.Name == KeywordStrings.Oscar)
                        unitGroup.Oscar = property.Value;
                    if (property.Name == KeywordStrings.Papa)
                        unitGroup.Papa = property.Value;
                    if (property.Name == KeywordStrings.Quebec)
                        unitGroup.Quebec = property.Value;
                    if (property.Name == KeywordStrings.Romeo)
                        unitGroup.Romeo = property.Value;
                    if (property.Name == KeywordStrings.Sierra)
                        unitGroup.Sierra = property.Value;
                    if (property.Name == KeywordStrings.Tango)
                        unitGroup.Tango = property.Value;
                    if (property.Name == KeywordStrings.Uniform)
                        unitGroup.Uniform = property.Value;
                    if (property.Name == KeywordStrings.Victor)
                        unitGroup.Victor = property.Value;
                    if (property.Name == KeywordStrings.Whiskey)
                        unitGroup.Whiskey = property.Value;
                    if (property.Name == KeywordStrings.Xray)
                        unitGroup.Xray = property.Value;
                    if (property.Name == KeywordStrings.Yankee)
                        unitGroup.Yankee = property.Value;
                    if (property.Name == KeywordStrings.Zulu)
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
                        if (settingProperty.Name == KeywordStrings.SyncAltSpawns)
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
                    if (property.Name == KeywordStrings.GroupName)
                        timedEventGroup.GroupName = property.Value;
                    if (property.Name == KeywordStrings.GroupId)
                        timedEventGroup.GroupId = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.BeginImmediately)
                        timedEventGroup.BeginImmediately = Convert.ToBoolean(property.Value);
                    if (property.Name == KeywordStrings.InitialDelay)
                        timedEventGroup.InitialDelay = Convert.ToInt32(property.Value);
                }

                foreach (VtsObject tei in teg.Children)
                {
                    TimedEventInfo timedEventInfo = new TimedEventInfo();

                    foreach (VtsProperty property in tei.Properties)
                    {
                        if (property.Name == KeywordStrings.EventName)
                            timedEventInfo.EventName = property.Value;
                        if (property.Name == KeywordStrings.Time)
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
                    if (property.Name == KeywordStrings.Id)
                        triggerEvent.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.Enabled)
                        triggerEvent.Enabled = Convert.ToBoolean(property.Value);
                    if (property.Name == KeywordStrings.TriggerType)
                        triggerEvent.TriggerType = property.Value;
                    if (property.Name == KeywordStrings.ConditionalProperty)
                        triggerEvent.Conditional = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.EventName)
                        triggerEvent.EventName = property.Value;
                    if (property.Name == KeywordStrings.WaypointProperty)
                    {
                        if (property.Value == KeywordStrings.Null)
                            triggerEvent.Waypoint = null;
                        else
                            triggerEvent.Waypoint = Convert.ToInt32(property.Value);
                    }
                    if (property.Name == KeywordStrings.Radius)
                        triggerEvent.Radius = Convert.ToSingle(property.Value);
                    if (property.Name == KeywordStrings.SphericalRadius)
                        triggerEvent.SphericalRadius = Convert.ToBoolean(property.Value);
                    if (property.Name == KeywordStrings.TriggerMode)
                        triggerEvent.TriggerMode = property.Value;
                    if (property.Name == KeywordStrings.ProxyMode)
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
                    if (property.Name == KeywordStrings.PrefabId)
                        staticObject.PrefabId = property.Value;
                    if (property.Name == KeywordStrings.Id)
                        staticObject.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.GlobalPos)
                        staticObject.GlobalPosition = property.Value;
                    if (property.Name == KeywordStrings.Rotation)
                        staticObject.Rotation = property.Value;
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
                    if (property.Name == KeywordStrings.Id)
                        conditionalAction.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.Name)
                        conditionalAction.Name = property.Value;
                }

                Block baseBlock = new Block();
                VtsObject bb = ca.Children[0];

                foreach (VtsProperty property in bb.Properties)
                {
                    if (property.Name == KeywordStrings.BlockName)
                        baseBlock.BlockName = property.Value;
                    if (property.Name == KeywordStrings.BlockId)
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
                            if (property.Name == KeywordStrings.BlockName)
                                elseIfBlock.BlockName = property.Value;
                            if (property.Name == KeywordStrings.BlockId)
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
                    if (property.Name == KeywordStrings.Id)
                        sequence.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.SequenceName)
                        sequence.SequenceName = property.Value;
                    if (property.Name == KeywordStrings.StartImmediately)
                        sequence.StartImmediately = Convert.ToBoolean(property.Value);
                    if (property.Name == KeywordStrings.WhileLoop)
                        sequence.WhileLoop = Convert.ToBoolean(property.Value);
                }

                foreach (VtsObject e in es.Children)
                {
                    Event @event = new Event();

                    foreach (VtsProperty property in e.Properties)
                    {
                        if (property.Name == KeywordStrings.ConditionalProperty)
                            @event.Conditional = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.Delay)
                            @event.Delay = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.NodeName)
                            @event.NodeName = property.Value;
                        if (property.Name == KeywordStrings.ExitConditional)
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
                    if (property.Name == KeywordStrings.Id)
                        baseInfo.Id = Convert.ToInt32(property.Value);
                    if (property.Name == KeywordStrings.OverrideBaseName)
                        baseInfo.OverrideBaseName = property.Value;
                    if (property.Name == KeywordStrings.BaseTeam)
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
                    if (property.Name == KeywordStrings.Text)
                        briefingNote.Text = property.Value;
                    if (property.Name == KeywordStrings.ImagePath)
                        briefingNote.ImagePath = property.Value;
                    if (property.Name == KeywordStrings.AudioClipPath)
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

            foreach (VtsProperty property in resourceManifest.Properties)
            {
                Resource resource = new Resource
                {
                    Index = Convert.ToInt32(property.Name),
                    Path = property.Value
                };

                scenario.ResourceManifest.Add(resource);
            }
        }

        private static Conditional ReadConditional(VtsObject con)
        {
            Conditional conditional = new Conditional();

            foreach (VtsProperty property in con.Properties)
            {
                if (property.Name == KeywordStrings.Id)
                    conditional.Id = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.OutputNodePos)
                    conditional.OutputNodePosition = property.Value;
                if (property.Name == KeywordStrings.Root)
                    conditional.Root = Convert.ToInt32(property.Value);
            }

            foreach (VtsObject child in con.Children)
            {
                Computation computation = new Computation();

                foreach (VtsProperty vtsProperty in child.Properties)
                {
                    if (vtsProperty.Name == KeywordStrings.Id)
                        computation.Id = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.Type)
                        computation.Type = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.UiPos)
                        computation.UiPosition = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.UnitGroup)
                        computation.UnitGroup = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.MethodName)
                        computation.MethodName = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.MethodParameters)
                        computation.MethodParameters = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.IsNot)
                        computation.IsNot = Convert.ToBoolean(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.Factors)
                        computation.Factors = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.GlobalValue)
                        computation.GlobalValue = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.Comparison)
                        computation.Comparison = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.C_Value)
                        computation.CValue = Convert.ToSingle(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.UnitList)
                        computation.UnitList = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.ObjectReference)
                        computation.ObjectReference = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.Chance)
                        computation.Chance = Convert.ToInt32(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.VehicleControl)
                        computation.VehicleControl = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.ControlCondition)
                        computation.ControlCondition = vtsProperty.Value;
                    if (vtsProperty.Name == KeywordStrings.ControlValue)
                        computation.ControlValue = Convert.ToSingle(vtsProperty.Value);
                    if (vtsProperty.Name == KeywordStrings.Unit)
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
                if (property.Name == KeywordStrings.EventName)
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
                if (property.Name == KeywordStrings.TargetType)
                    eventTarget.TargetType = property.Value;
                if (property.Name == KeywordStrings.TargetId)
                    eventTarget.TargetId = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.EventName)
                    eventTarget.EventName = property.Value;
                if (property.Name == KeywordStrings.MethodName)
                    eventTarget.MethodName = property.Value;
            }

            foreach (VtsObject pi in et.Children)
            {
                ParamInfo paramInfo = new ParamInfo();

                foreach (VtsProperty property in pi.Properties)
                {
                    if (property.Name == KeywordStrings.Type)
                        paramInfo.Type = property.Value;
                    if (property.Name == KeywordStrings.Value)
                        paramInfo.Value = property.Value;
                    if (property.Name == KeywordStrings.Name)
                        paramInfo.Name = property.Value;
                }

                foreach (VtsObject pai in pi.Children)
                {
                    ParamAttrInfo paramAttrInfo = new ParamAttrInfo();

                    foreach (VtsProperty property in pai.Properties)
                    {
                        if (property.Name == KeywordStrings.Type)
                            paramAttrInfo.Type = property.Value;
                        if (property.Name == KeywordStrings.Data)
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
                if (property.Name == KeywordStrings.ObjectiveName)
                    objective.ObjectiveName = property.Value;
                if (property.Name == KeywordStrings.ObjectiveInfo)
                    objective.ObjectiveInfo = property.Value;
                if (property.Name == KeywordStrings.ObjectiveId)
                    objective.ObjectiveID = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.OrderId)
                    objective.OrderID = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.Required)
                    objective.Required = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.CompletionReward)
                    objective.CompletionReward = Convert.ToInt32(property.Value);
                if (property.Name == KeywordStrings.WaypointProperty)
                    objective.Waypoint = property.Value;
                if (property.Name == KeywordStrings.AutoSetWaypoint)
                    objective.AutoSetWaypoint = Convert.ToBoolean(property.Value);
                if (property.Name == KeywordStrings.StartMode)
                    objective.StartMode = property.Value;
                if (property.Name == KeywordStrings.ObjectiveType)
                    objective.ObjectiveType = property.Value;
                if (property.Name == KeywordStrings.PreReqObjectives)
                    objective.PreReqObjectives = property.Value;
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
                        if (property.Name == KeywordStrings.SuccessConditional)
                            objectiveFields.SuccessConditional = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.FailConditional)
                            objectiveFields.FailConditional = property.Value == KeywordStrings.Null ? null : Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.Targets)
                            objectiveFields.Targets = property.Value;
                        if (property.Name == KeywordStrings.MinRequired)
                            objectiveFields.MinRequired = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.PerUnitReward)
                            objectiveFields.PerUnitReward = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.FullCompleteBonus)
                            objectiveFields.FullCompletionBonus = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.UnloadRadius)
                            objectiveFields.UnloadRadius = Convert.ToSingle(property.Value);
                        if (property.Name == KeywordStrings.DropoffRallyPt)
                            objectiveFields.DropoffRallyPoint = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.TriggerRadius)
                            objectiveFields.TriggerRadius = Convert.ToSingle(property.Value);
                        if (property.Name == KeywordStrings.SphericalRadius)
                            objectiveFields.SphericalRadius = Convert.ToBoolean(property.Value);
                        if (property.Name == KeywordStrings.TargetUnit)
                            objectiveFields.TargetUnit = Convert.ToInt32(property.Value);
                        if (property.Name == KeywordStrings.Radius)
                            objectiveFields.Radius = Convert.ToSingle(property.Value);
                        if (property.Name == KeywordStrings.FuelLevel)
                            objectiveFields.FuelLevel = Convert.ToSingle(property.Value);
                        if (property.Name == KeywordStrings.CompletionMode)
                            objectiveFields.CompletionMode = property.Value;
                        if (property.Name == KeywordStrings.Target)
                            objectiveFields.Target = Convert.ToInt32(property.Value);
                    }

                    objective.Fields = objectiveFields;
                }
            }

            return objective;
        }

        /// <summary>Reads the VTS file into a CustomScenario object.</summary>
        /// <param name="vtsFile">The VTS file to read.</param>
        /// <returns>The CustomScenario object containing the contents of the file or one with the HasError property set if a problem occurred.</returns>
        public static CustomScenario ReadVtsFile(string vtsFile)
        {
            if (string.IsNullOrWhiteSpace(vtsFile))
                throw new ArgumentException("vtsFile cannot be empty, null or consist of white-space characters only.");

            if (!System.IO.File.Exists(vtsFile))
                throw new ArgumentException("File must exist!");

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

                if (DiagnosticOptions.OutputReadWriteTimes)
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
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.GameVersion, Value = scenario.GameVersion, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.CampaignId, Value = scenario.CampaignId == null ? "" : scenario.CampaignId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.CampaignOrderIdx, Value = scenario.CampaignOrderIndex.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.ScenarioName, Value = scenario.ScenarioName, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.ScenarioId, Value = scenario.ScenarioId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.ScenarioDescription, Value = scenario.ScenarioDescription == null ? "" : scenario.ScenarioDescription, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.MapId, Value = scenario.MapId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.Vehicle, Value = scenario.Vehicle, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.Multiplayer, Value = scenario.Multiplayer ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });

            if (!string.IsNullOrWhiteSpace(scenario.AllowedEquips) && !scenario.AllowedEquips.Equals(KeywordStrings.None, StringComparison.OrdinalIgnoreCase))
                cs.Properties.Add(new VtsProperty { Name = KeywordStrings.AllowedEquips, Value = scenario.AllowedEquips, IndentDepth = 1 });

            string forcedEquips = ";;;;;;;"; // AV-42C

            if (scenario.Vehicle == KeywordStrings.Fa26B)
                forcedEquips = ";;;;;;;;;;;;;;;;";

            if (scenario.Vehicle == KeywordStrings.F45A)
                forcedEquips = ";;;;;;;;;;;";

            // todo : I do not have the helicopter DLC so I cannot setup missions to test this data but fill this in at some point
            //if (scenario.Vehicle == "Helicopter")
            //    forcedEquips = ";;;;";

            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.ForcedEquips, Value = string.IsNullOrWhiteSpace(scenario.ForcedEquips) ? forcedEquips : scenario.ForcedEquips, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.ForceEquips, Value = scenario.ForceEquips ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.NormForcedFuel, Value = scenario.NormalForcedFuel.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.EquipsConfigurable, Value = scenario.EquipsConfigurable ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.BaseBudget, Value = scenario.BaseBudget.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.IsTraining, Value = scenario.IsTraining ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.RtbWptId, Value = scenario.ReturnToBaseWaypointId == null ? "" : scenario.ReturnToBaseWaypointId, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.RefuelWptId, Value = scenario.RefuelWaypointId == null ? "" : scenario.RefuelWaypointId, IndentDepth = 1 });

            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.InfiniteAmmo, Value = scenario.InfiniteAmmo ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.InfAmmoReloadDelay, Value = scenario.InfiniteAmmoReloadDelay.ToString(), IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.FuelDrainMult, Value = scenario.FuelDrainMultiplier.ToString(), IndentDepth = 1 });

            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.EnvName, Value = scenario.EnvironmentName, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.SelectableEnv, Value = scenario.SelectableEnvironment ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.QsMode, Value = scenario.QuickSaveMode, IndentDepth = 1 });
            cs.Properties.Add(new VtsProperty { Name = KeywordStrings.QsLimit, Value = scenario.QuickSaveLimit.ToString(), IndentDepth = 1 });
        }

        private static void WriteUnits(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject units = new VtsObject { Name = KeywordStrings.Units, IndentDepth = 1 };

            foreach (UnitSpawner unitSpawner in scenario.Units)
            {
                VtsObject unit = new VtsObject { Name = KeywordStrings.UnitSpawner, IndentDepth = 2 };
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitName, Value = unitSpawner.UnitName, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.GlobalPosition, Value = unitSpawner.GlobalPosition.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitInstanceId, Value = unitSpawner.UnitInstanceId.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitId, Value = unitSpawner.UnitId, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.Rotation, Value = unitSpawner.Rotation.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.SpawnChance, Value = unitSpawner.SpawnChance.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.LastValidPlacement, Value = unitSpawner.LastValidPlacement.ToString(), IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.EditorPlacementMode, Value = unitSpawner.EditorPlacementMode, IndentDepth = 3 });
                unit.Properties.Add(new VtsProperty { Name = KeywordStrings.SpawnFlags, Value = string.IsNullOrWhiteSpace(unitSpawner.SpawnFlags) ? "" : unitSpawner.SpawnFlags, IndentDepth = 3 });

                // process unit fields
                VtsObject unitFields = new VtsObject() { Name = KeywordStrings.UnitFields, IndentDepth = 3 };

                IReadOnlyList<string> propertiesForUnitFields = UnitFields.GetUnitFieldsForUnitType(unitSpawner.UnitId);
                
                foreach (string property in propertiesForUnitFields)
                {
                    if (property == KeywordStrings.UnitGroup)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitGroup, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.UnitGroup) ? KeywordStrings.Null : unitSpawner.UnitFields.UnitGroup, IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultBehavior)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultBehavior, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultBehavior) ? KeywordStrings.Null : unitSpawner.UnitFields.DefaultBehavior, IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultWaypoint)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultWaypoint, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultWaypoint) ? KeywordStrings.Null : unitSpawner.UnitFields.DefaultWaypoint, IndentDepth = 4 });
                    if (property== KeywordStrings.DefaultPath)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultPath, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultPath) ? KeywordStrings.Null : unitSpawner.UnitFields.DefaultPath, IndentDepth = 4 });
                    if (property == KeywordStrings.HullNumber)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.HullNumber, Value = unitSpawner.UnitFields.HullNumber.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.EngageEnemies)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.EngageEnemies, Value = unitSpawner.UnitFields.EngageEnemies ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.DetectionMode)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DetectionMode, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DetectionMode) ? KeywordStrings.Null : unitSpawner.UnitFields.DetectionMode, IndentDepth = 4 });
                    if (property == KeywordStrings.SpawnOnStart)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.SpawnOnStart, Value = unitSpawner.UnitFields.SpawnOnStart ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.Invincible)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Invincible, Value = unitSpawner.UnitFields.Invincible ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.Respawnable)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Respawnable, Value = unitSpawner.UnitFields.Respawnable ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.CarrierSpawns)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.CarrierSpawns, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.CarrierSpawns) ? "" : unitSpawner.UnitFields.CarrierSpawns, IndentDepth = 4 });
                    if (property == KeywordStrings.RadarUnits)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.RadarUnits, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.RadarUnits) ? "" : unitSpawner.UnitFields.RadarUnits, IndentDepth = 4 });
                    if (property == KeywordStrings.AllowReload)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.AllowReload, Value = unitSpawner.UnitFields.AllowReload ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.ReloadTime)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.ReloadTime, Value = unitSpawner.UnitFields.ReloadTime.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.CombatTarget)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.CombatTarget, Value = unitSpawner.UnitFields.CombatTarget ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.MoveSpeed)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.MoveSpeed, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.MoveSpeed) ? KeywordStrings.Null : unitSpawner.UnitFields.MoveSpeed, IndentDepth = 4 });
                    if (property == KeywordStrings.Behavior)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Behavior, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Behavior) ? KeywordStrings.Null : unitSpawner.UnitFields.Behavior, IndentDepth = 4 });
                    if (property == KeywordStrings.WaypointProperty)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.WaypointProperty, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Waypoint) ? KeywordStrings.Null : unitSpawner.UnitFields.Waypoint, IndentDepth = 4 });
                    if (property == KeywordStrings.VoiceProfile)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.VoiceProfile, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.VoiceProfile) ? KeywordStrings.Null : unitSpawner.UnitFields.VoiceProfile, IndentDepth = 4 });
                    if (property == KeywordStrings.PlayerCommandsMode)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.PlayerCommandsMode, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.PlayerCommandsMode) ? KeywordStrings.Null : unitSpawner.UnitFields.PlayerCommandsMode, IndentDepth = 4 });
                    if (property == KeywordStrings.InitialSpeed)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.InitialSpeed, Value = unitSpawner.UnitFields.InitialSpeed.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultNavSpeed)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultNavSpeed, Value = unitSpawner.UnitFields.DefaultNavSpeed.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultOrbitPoint)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultOrbitPoint, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.DefaultOrbitPoint) ? KeywordStrings.Null : unitSpawner.UnitFields.DefaultOrbitPoint, IndentDepth = 4 });
                    if (property == KeywordStrings.OrbitAltitude)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.OrbitAltitude, Value = unitSpawner.UnitFields.OrbitAltitude.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.Fuel)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Fuel, Value = unitSpawner.UnitFields.Fuel.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.AutoRefuel)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.AutoRefuel, Value = unitSpawner.UnitFields.AutoRefuel ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.AutoRtb)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.AutoRtb, Value = unitSpawner.UnitFields.AutoReturnToBase ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.RtbDestination)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.RtbDestination, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.ReturnToBaseDestination) ? "" : unitSpawner.UnitFields.ReturnToBaseDestination, IndentDepth = 4 });
                    if (property == KeywordStrings.ParkedStartMode)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.ParkedStartMode, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.ParkedStartMode) ? KeywordStrings.Null : unitSpawner.UnitFields.ParkedStartMode, IndentDepth = 4 });
                    if (property == KeywordStrings.Equips && !string.IsNullOrWhiteSpace(unitSpawner.UnitFields.Equips))
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Equips, Value = unitSpawner.UnitFields.Equips, IndentDepth = 4 });                     
                    if (property == KeywordStrings.StopToEngage)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.StopToEngage, Value = unitSpawner.UnitFields.StopToEngage ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.StartMode)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.StartMode, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.StartMode) ? KeywordStrings.Null : unitSpawner.UnitFields.StartMode, IndentDepth = 4 });
                    if (property == KeywordStrings.ReceiveFriendlyDamage)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.ReceiveFriendlyDamage, Value = unitSpawner.UnitFields.ReceiveFriendlyDamage ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultRadarEnabled)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultRadarEnabled, Value = unitSpawner.UnitFields.DefaultRadarEnabled ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.AwacsVoiceProfile)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.AwacsVoiceProfile, Value = string.IsNullOrWhiteSpace(unitSpawner.UnitFields.AwacsVoiceProfile) ? KeywordStrings.Null : unitSpawner.UnitFields.AwacsVoiceProfile, IndentDepth = 4 });
                    if (property == KeywordStrings.CommsEnabled)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.CommsEnabled, Value = unitSpawner.UnitFields.CommsEnabled ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 4 });
                    if (property == KeywordStrings.DefaultShotsPerSalvo)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DefaultShotsPerSalvo, Value = unitSpawner.UnitFields.DefaultShotsPerSalvo.ToString(), IndentDepth = 4 });
                    if (property == KeywordStrings.RippleRate)
                        unitFields.Properties.Add(new VtsProperty { Name = KeywordStrings.RippleRate, Value = unitSpawner.UnitFields.RippleRate.ToString(), IndentDepth = 4 });
                }

                unit.Children.Add(unitFields);

                units.Children.Add(unit);
            }

            cs.Children.Add(units);
        }

        private static void WritePaths(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject paths = new VtsObject { Name = KeywordStrings.Paths, IndentDepth = 1 };

            foreach (Path path in scenario.Paths)
            {
                VtsObject p = new VtsObject { Name = KeywordStrings.Path, IndentDepth = 2 };
                p.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = path.Id.ToString(), IndentDepth = 3 });
                p.Properties.Add(new VtsProperty { Name = KeywordStrings.Name, Value = path.Name, IndentDepth = 3 });
                p.Properties.Add(new VtsProperty { Name = KeywordStrings.Loop, Value = path.Loop ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                p.Properties.Add(new VtsProperty { Name = KeywordStrings.Points, Value = string.Join(';', path.Points) + ";", IndentDepth = 3 });
                p.Properties.Add(new VtsProperty { Name = KeywordStrings.PathMode, Value = path.PathMode.ToString(), IndentDepth = 3 });

                paths.Children.Add(p);
            }

            cs.Children.Add(paths);
        }

        private static void WriteWaypoints(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject waypoints = new VtsObject { Name = KeywordStrings.Waypoints, IndentDepth = 1 };

            for (int i = 0; i < scenario.Waypoints.GetPropertyCount(); i++)
            {
                DictionaryEntry property = scenario.Waypoints.GetProperty(i);

                waypoints.Properties.Add(new VtsProperty { Name = property.Key.ToString(), Value = property.Value.ToString(), IndentDepth = 2 });
            }

            foreach (Waypoint waypoint in scenario.Waypoints)
            {
                VtsObject wp = new VtsObject { Name = KeywordStrings.Waypoint, IndentDepth = 2 };
                wp.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = waypoint.Id.ToString(), IndentDepth = 3 });
                wp.Properties.Add(new VtsProperty { Name = KeywordStrings.Name, Value = waypoint.Name, IndentDepth = 3 });
                wp.Properties.Add(new VtsProperty { Name = KeywordStrings.GlobalPoint, Value = waypoint.GlobalPoint.ToString(), IndentDepth = 3 });

                waypoints.Children.Add(wp);
            }

            cs.Children.Add(waypoints);
        }

        private static void WriteUnitGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject unitGroups = new VtsObject { Name = KeywordStrings.UnitGroups, IndentDepth = 1 };

            UnitGroup alliedUG = scenario.UnitGroups.FirstOrDefault(ug => ug.Name == KeywordStrings.Allied);

            if (alliedUG != null)
            {
                // check to make sure we even need to write the unit group
                // needs to be any unit group with data
                if (!string.IsNullOrWhiteSpace(alliedUG.Alpha) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Bravo) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Charlie) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Delta) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Echo) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Foxtrot) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Golf) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Hotel) ||
                    !string.IsNullOrWhiteSpace(alliedUG.India) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Juliet) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Kilo) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Lima) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Mike) ||
                    !string.IsNullOrWhiteSpace(alliedUG.November) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Oscar) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Papa) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Quebec) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Romeo) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Sierra) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Tango) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Uniform) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Victor) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Whiskey) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Xray) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Yankee) ||
                    !string.IsNullOrWhiteSpace(alliedUG.Zulu))
                {
                    VtsObject allied = new VtsObject { Name = KeywordStrings.Allied, IndentDepth = 2 };

                    WriteUnitGroupProperties(alliedUG, allied);

                    unitGroups.Children.Add(allied);
                }
            }

            UnitGroup enemyUG = scenario.UnitGroups.FirstOrDefault(ug => ug.Name == KeywordStrings.Enemy);

            if (enemyUG != null)
            {
                // check to make sure we even need to write the unit group
                // needs to be any unit group with data
                if (!string.IsNullOrWhiteSpace(enemyUG.Alpha) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Bravo) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Charlie) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Delta) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Echo) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Foxtrot) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Golf) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Hotel) ||
                    !string.IsNullOrWhiteSpace(enemyUG.India) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Juliet) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Kilo) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Lima) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Mike) ||
                    !string.IsNullOrWhiteSpace(enemyUG.November) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Oscar) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Papa) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Quebec) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Romeo) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Sierra) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Tango) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Uniform) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Victor) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Whiskey) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Xray) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Yankee) ||
                    !string.IsNullOrWhiteSpace(enemyUG.Zulu))
                {
                    VtsObject enemy = new VtsObject { Name = KeywordStrings.Enemy, IndentDepth = 2 };

                    WriteUnitGroupProperties(enemyUG, enemy);

                    unitGroups.Children.Add(enemy);
                }
            }

            cs.Children.Add(unitGroups);
        }

        private static void WriteUnitGroupProperties(UnitGroup unitGroup, VtsObject ug)
        {
            if (unitGroup == null) return;

            if (!string.IsNullOrWhiteSpace(unitGroup.Alpha))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Alpha, Value = unitGroup.Alpha, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Alpha);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Bravo))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Bravo, Value = unitGroup.Bravo, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Bravo);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Charlie))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Charlie, Value = unitGroup.Charlie, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Charlie);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Delta))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Delta, Value = unitGroup.Delta, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Delta);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Echo))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Echo, Value = unitGroup.Echo, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Echo);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Foxtrot))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Foxtrot, Value = unitGroup.Foxtrot, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Foxtrot);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Golf))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Golf, Value = unitGroup.Golf, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Golf);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Hotel))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Hotel, Value = unitGroup.Hotel, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Hotel);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.India))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.India, Value = unitGroup.India, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.India);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Juliet))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Juliet, Value = unitGroup.Juliet, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Juliet);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Kilo))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Kilo, Value = unitGroup.Kilo, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Kilo);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Lima))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Lima, Value = unitGroup.Lima, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Lima);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Mike))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Mike, Value = unitGroup.Mike, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Mike);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.November))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.November, Value = unitGroup.November, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.November);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Oscar))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Oscar, Value = unitGroup.Oscar, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Oscar);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Papa))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Papa, Value = unitGroup.Papa, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Papa);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Quebec))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Quebec, Value = unitGroup.Quebec, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Quebec);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Romeo))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Romeo, Value = unitGroup.Romeo, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Romeo);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Sierra))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Sierra, Value = unitGroup.Sierra, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Sierra);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Tango))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Tango, Value = unitGroup.Tango, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Tango);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Uniform))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Uniform, Value = unitGroup.Uniform, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Uniform);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Victor))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Victor, Value = unitGroup.Victor, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Victor);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Whiskey))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Whiskey, Value = unitGroup.Whiskey, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Whiskey);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Xray))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Xray, Value = unitGroup.Xray, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Xray);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Yankee))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Yankee, Value = unitGroup.Yankee, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Yankee);
            }
            if (!string.IsNullOrWhiteSpace(unitGroup.Zulu))
            {
                ug.Properties.Add(new VtsProperty { Name = KeywordStrings.Zulu, Value = unitGroup.Zulu, IndentDepth = 3 });

                WriteUnitGroupSettings(unitGroup, ug, KeywordStrings.Zulu);
            }
        }

        private static void WriteUnitGroupSettings(UnitGroup unitGroup, VtsObject ug, string name)
        {
            UnitGroupSettings unitGroupSettings = unitGroup.UnitGroupSettings.FirstOrDefault(x => x.Name == $"{name}_SETTINGS");

            // if we don't find a match should we throw an exception of some kind?
            if (unitGroupSettings == null) return;

            VtsObject ugs = new VtsObject { Name = $"{name}{KeywordStrings.UnitGroupSettingsExtension}", IndentDepth = 3 };
            ugs.Properties.Add(new VtsProperty { Name = KeywordStrings.SyncAltSpawns, Value = unitGroupSettings.SyncAltSpawns, IndentDepth = 4 });

            ug.Children.Add(ugs);
        }

        private static void WriteTimedEventGroups(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject tegs = new VtsObject { Name = KeywordStrings.TimedEventGroups, IndentDepth = 1 };

            foreach (TimedEventGroup timedEventGroup in scenario.TimedEventGroups)
            {
                VtsObject teg = new VtsObject { Name = KeywordStrings.TimedEventGroup, IndentDepth = 2 };
                teg.Properties.Add(new VtsProperty { Name = KeywordStrings.GroupName, Value = timedEventGroup.GroupName, IndentDepth = 3 });
                teg.Properties.Add(new VtsProperty { Name = KeywordStrings.GroupId, Value = timedEventGroup.GroupId.ToString(), IndentDepth = 3 });
                teg.Properties.Add(new VtsProperty { Name = KeywordStrings.BeginImmediately, Value = timedEventGroup.BeginImmediately ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                teg.Properties.Add(new VtsProperty { Name = KeywordStrings.InitialDelay, Value = timedEventGroup.InitialDelay.ToString(), IndentDepth = 3 });

                foreach (TimedEventInfo timedEventInfo in timedEventGroup.TimedEventInfos)
                {
                    VtsObject tei = new VtsObject { Name = KeywordStrings.TimedEventInfo, IndentDepth = 3 };
                    tei.Properties.Add(new VtsProperty { Name = KeywordStrings.EventName, Value = timedEventInfo.EventName, IndentDepth = 4 });
                    tei.Properties.Add(new VtsProperty { Name = KeywordStrings.Time, Value = timedEventInfo.Time.ToString(), IndentDepth = 4 });

                    foreach (EventTarget eventTarget in timedEventInfo.EventTargets)
                    {
                        tei.Children.Add(WriteEventTarget(eventTarget, 4));
                    }

                    teg.Children.Add(tei);
                }

                tegs.Children.Add(teg);
            }

            cs.Children.Add(tegs);
        }

        private static VtsObject WriteEventTarget(EventTarget eventTarget, int indentDepth)
        {
            VtsObject et = new VtsObject { Name = KeywordStrings.EventTarget, IndentDepth = indentDepth };
            et.Properties.Add(new VtsProperty { Name = KeywordStrings.TargetType, Value = eventTarget.TargetType, IndentDepth = indentDepth + 1 });
            et.Properties.Add(new VtsProperty { Name = KeywordStrings.TargetId, Value = eventTarget.TargetId.ToString(), IndentDepth = indentDepth + 1 });
            et.Properties.Add(new VtsProperty { Name = KeywordStrings.EventName, Value = eventTarget.EventName, IndentDepth = indentDepth + 1 });
            et.Properties.Add(new VtsProperty { Name = KeywordStrings.MethodName, Value = eventTarget.MethodName, IndentDepth = indentDepth + 1 });

            foreach (ParamInfo paramInfo in eventTarget.ParamInfos)
            {
                VtsObject pi = new VtsObject { Name = KeywordStrings.ParamInfo, IndentDepth = indentDepth + 1 };
                pi.Properties.Add(new VtsProperty { Name = KeywordStrings.Type, Value = paramInfo.Type, IndentDepth = indentDepth + 2 });
                pi.Properties.Add(new VtsProperty { Name = KeywordStrings.Value, Value = paramInfo.Value, IndentDepth = indentDepth + 2 });
                pi.Properties.Add(new VtsProperty { Name = KeywordStrings.Name, Value = paramInfo.Name, IndentDepth = indentDepth + 2 });

                foreach (ParamAttrInfo paramAttrInfo in paramInfo.ParamAttrInfos)
                {
                    VtsObject pai = new VtsObject { Name = KeywordStrings.ParamAttrInfo, IndentDepth = indentDepth + 2 };
                    pai.Properties.Add(new VtsProperty { Name = KeywordStrings.Type, Value = paramAttrInfo.Type, IndentDepth = indentDepth + 3 });
                    pai.Properties.Add(new VtsProperty { Name = KeywordStrings.Data, Value = paramAttrInfo.Data, IndentDepth = indentDepth + 3 });

                    pi.Children.Add(pai);
                }

                et.Children.Add(pi);
            }

            return et;
        }

        private static void WriteTriggerEvents(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject tes = new VtsObject { Name = KeywordStrings.TriggerEvents, IndentDepth = 1 };

            foreach (TriggerEvent triggerEvent in scenario.TriggerEvents)
            {
                VtsObject te = new VtsObject { Name = KeywordStrings.TriggerEvent, IndentDepth = 2 };
                te.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = triggerEvent.Id.ToString(), IndentDepth = 3 });
                te.Properties.Add(new VtsProperty { Name = KeywordStrings.Enabled, Value = triggerEvent.Enabled ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                te.Properties.Add(new VtsProperty { Name = KeywordStrings.TriggerType, Value = triggerEvent.TriggerType, IndentDepth = 3 });

                if (triggerEvent.Conditional.HasValue)
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.ConditionalProperty, Value = triggerEvent.Conditional.Value.ToString(), IndentDepth = 3 });

                if (triggerEvent.Waypoint.HasValue)
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.WaypointProperty, Value = triggerEvent.Waypoint.Value.ToString(), IndentDepth = 3 });
                else if (!triggerEvent.Waypoint.HasValue && triggerEvent.TriggerType == KeywordStrings.Proximity)
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.WaypointProperty, Value = KeywordStrings.Null, IndentDepth = 3 });

                if (triggerEvent.Radius.HasValue)
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.Radius, Value = triggerEvent.Radius.Value.ToString(), IndentDepth = 3 });

                if (triggerEvent.SphericalRadius.HasValue)
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.SphericalRadius, Value = triggerEvent.SphericalRadius.Value ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });

                if (!string.IsNullOrWhiteSpace(triggerEvent.TriggerMode))
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.TriggerMode, Value = triggerEvent.TriggerMode, IndentDepth = 3 });

                if (!string.IsNullOrWhiteSpace(triggerEvent.ProxyMode))
                    te.Properties.Add(new VtsProperty { Name = KeywordStrings.ProxyMode, Value = triggerEvent.ProxyMode, IndentDepth = 3 });

                te.Properties.Add(new VtsProperty { Name = KeywordStrings.EventName, Value = triggerEvent.EventName, IndentDepth = 3 });

                te.Children.Add(WriteEventInfo(triggerEvent.EventInfo, 3, 0));

                tes.Children.Add(te);
            }

            cs.Children.Add(tes);
        }

        private static VtsObject WriteEventInfo(EventInfo eventInfo, int indentDepth, int stringToUse)
        {
            VtsObject ei = new VtsObject { Name = stringToUse == 0 ? KeywordStrings.EventInfo : stringToUse == 1 ? KeywordStrings.Actions : stringToUse == 2 ? KeywordStrings.ElseActions : KeywordStrings.EventInfo, IndentDepth = indentDepth };
            ei.Properties.Add(new VtsProperty { Name = KeywordStrings.EventName, Value = eventInfo.EventName, IndentDepth = indentDepth + 1 });

            foreach (EventTarget eventTarget in eventInfo.EventTargets)
            {
                ei.Children.Add(WriteEventTarget(eventTarget, indentDepth + 1));
            }

            return ei;
        }

        private static VtsObject WriteObjectives(bool isOpFor, List<Objective> objectives)
        {
            VtsObject objs = new VtsObject { Name = isOpFor ? KeywordStrings.ObjectivesOpFor : KeywordStrings.Objectives, IndentDepth = 1 };

            foreach (Objective objective in objectives)
            {
                VtsObject obj = new VtsObject { Name = KeywordStrings.Objective, IndentDepth = 2 };
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.ObjectiveName, Value = objective.ObjectiveName, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.ObjectiveInfo, Value = objective.ObjectiveInfo, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.ObjectiveId, Value = objective.ObjectiveID.ToString(), IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.OrderId, Value = objective.OrderID.ToString(), IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.Required, Value = objective.Required ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.CompletionReward, Value = objective.CompletionReward.ToString(), IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.WaypointProperty, Value = string.IsNullOrWhiteSpace(objective.Waypoint) ? KeywordStrings.Null : objective.Waypoint, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.AutoSetWaypoint, Value = objective.AutoSetWaypoint ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.StartMode, Value = objective.StartMode, IndentDepth = 3 });
                obj.Properties.Add(new VtsProperty { Name = KeywordStrings.ObjectiveType, Value = objective.ObjectiveType, IndentDepth = 3 });

                if (!string.IsNullOrWhiteSpace(objective.PreReqObjectives))
                    obj.Properties.Add(new VtsProperty { Name = KeywordStrings.PreReqObjectives, Value = objective.PreReqObjectives, IndentDepth = 3 });

                VtsObject startEvent = new VtsObject { Name = KeywordStrings.StartEvent, IndentDepth = 3 };
                startEvent.Children.Add(WriteEventInfo(objective.StartEvent, 4, 0));

                obj.Children.Add(startEvent);

                VtsObject failEvent = new VtsObject { Name = KeywordStrings.FailEvent, IndentDepth = 3 };
                failEvent.Children.Add(WriteEventInfo(objective.FailEvent, 4, 0));

                obj.Children.Add(failEvent);

                VtsObject completeEvent = new VtsObject { Name = KeywordStrings.CompleteEvent, IndentDepth = 3 };
                completeEvent.Children.Add(WriteEventInfo(objective.CompleteEvent, 4, 0));

                obj.Children.Add(completeEvent);

                VtsObject objectiveFields = new VtsObject { Name = KeywordStrings.Fields, IndentDepth = 3 };

                if (objective.Fields.SuccessConditional.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.SuccessConditional, Value = objective.Fields.SuccessConditional.Value.ToString(), IndentDepth = 4 });
                else if (!objective.Fields.SuccessConditional.HasValue && objective.ObjectiveType == KeywordStrings.ObjectiveTypeConditional)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.SuccessConditional, Value = KeywordStrings.Null, IndentDepth = 4 });

                if (objective.Fields.FailConditional.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.FailConditional, Value = objective.Fields.FailConditional.Value.ToString(), IndentDepth = 4 });
                else if (!objective.Fields.FailConditional.HasValue && objective.ObjectiveType == KeywordStrings.ObjectiveTypeConditional)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.FailConditional, Value = KeywordStrings.Null, IndentDepth = 4 });

                if (!string.IsNullOrWhiteSpace(objective.Fields.Targets))
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Targets, Value = objective.Fields.Targets, IndentDepth = 4 });

                if (objective.Fields.MinRequired.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.MinRequired, Value = objective.Fields.MinRequired.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.PerUnitReward.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.PerUnitReward, Value = objective.Fields.PerUnitReward.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.FullCompletionBonus.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.FullCompleteBonus, Value = objective.Fields.FullCompletionBonus.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.UnloadRadius.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.UnloadRadius, Value = objective.Fields.UnloadRadius.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.DropoffRallyPoint.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.DropoffRallyPt, Value = objective.Fields.DropoffRallyPoint.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.TriggerRadius.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.TriggerRadius, Value = objective.Fields.TriggerRadius.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.SphericalRadius.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.SphericalRadius, Value = objective.Fields.SphericalRadius.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.TargetUnit.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.TargetUnit, Value = objective.Fields.TargetUnit.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.Target.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Target, Value = objective.Fields.Target.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.Radius.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.Radius, Value = objective.Fields.Radius.Value.ToString(), IndentDepth = 4 });

                if (objective.Fields.FuelLevel.HasValue)
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.FuelLevel, Value = objective.Fields.FuelLevel.Value.ToString(), IndentDepth = 4 });

                if (!string.IsNullOrWhiteSpace(objective.Fields.CompletionMode))
                    objectiveFields.Properties.Add(new VtsProperty { Name = KeywordStrings.CompletionMode, Value = objective.Fields.CompletionMode, IndentDepth = 4 });

                obj.Children.Add(objectiveFields);

                objs.Children.Add(obj);
            }

            return objs;
        }

        private static void WriteObjectives(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            cs.Children.Add(WriteObjectives(false, scenario.Objectives));
        }

        private static void WriteObjectvesOpFor(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            cs.Children.Add(WriteObjectives(true, scenario.ObjectivesOpFor));
        }

        private static void WriteStaticObjects(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject sos = new VtsObject { Name = KeywordStrings.StaticObjects, IndentDepth = 1 };

            foreach (StaticObject staticObject in scenario.StaticObjects)
            {
                VtsObject so = new VtsObject { Name = KeywordStrings.StaticObject, IndentDepth = 2 };
                so.Properties.Add(new VtsProperty { Name = KeywordStrings.PrefabId, Value = staticObject.PrefabId, IndentDepth = 3 });
                so.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = staticObject.Id.ToString(), IndentDepth = 3 });
                so.Properties.Add(new VtsProperty { Name = KeywordStrings.GlobalPos, Value = staticObject.GlobalPosition.ToString(), IndentDepth = 3 });
                so.Properties.Add(new VtsProperty { Name = KeywordStrings.Rotation, Value = staticObject.Rotation.ToString(), IndentDepth = 3 });

                sos.Children.Add(so);
            }

            cs.Children.Add(sos);
        }

        private static VtsObject WriteConditional(Conditional conditional, int indentDepth)
        {
            VtsObject c = new VtsObject { Name = KeywordStrings.Conditional, IndentDepth = indentDepth };
            c.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = conditional.Id.ToString(), IndentDepth = indentDepth + 1 });
            c.Properties.Add(new VtsProperty { Name = KeywordStrings.OutputNodePos, Value = conditional.OutputNodePosition.ToString(), IndentDepth = indentDepth + 1 });

            if (conditional.Root.HasValue)
                c.Properties.Add(new VtsProperty { Name = KeywordStrings.Root, Value = conditional.Root.Value.ToString(), IndentDepth = indentDepth + 1 });

            foreach (Computation computation in conditional.Computations)
            {
                VtsObject comp = new VtsObject { Name = KeywordStrings.Comp, IndentDepth = indentDepth + 1 };
                comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = computation.Id.ToString(), IndentDepth = indentDepth + 2 });
                comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Type, Value = computation.Type, IndentDepth = indentDepth + 2 });
                comp.Properties.Add(new VtsProperty { Name = KeywordStrings.UiPos, Value = computation.UiPosition.ToString(), IndentDepth = indentDepth + 2 });

                if (computation.Unit.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Unit, Value = computation.Unit.ToString(), IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.UnitGroup))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitGroup, Value = computation.UnitGroup, IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.UnitList))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.UnitList, Value = computation.UnitList, IndentDepth = indentDepth + 2 });

                if (computation.ObjectReference.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.ObjectReference, Value = computation.ObjectReference.ToString(), IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.MethodName))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.MethodName, Value = computation.MethodName, IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.MethodParameters))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.MethodParameters, Value = computation.MethodParameters, IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.Factors))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Factors, Value = computation.Factors, IndentDepth = indentDepth + 2 });

                if (computation.Chance.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Chance, Value = computation.Chance.ToString(), IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.VehicleControl))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.VehicleControl, Value = computation.VehicleControl, IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.ControlCondition))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.ControlCondition, Value = computation.ControlCondition, IndentDepth = indentDepth + 2 });

                if (computation.ControlValue.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.ControlValue, Value = computation.ControlValue.ToString(), IndentDepth = indentDepth + 2 });

                if (computation.GlobalValue.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.GlobalValue, Value = computation.GlobalValue.ToString(), IndentDepth = indentDepth + 2 });

                if (!string.IsNullOrWhiteSpace(computation.Comparison))
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.Comparison, Value = computation.Comparison, IndentDepth = indentDepth + 2 });

                if (computation.CValue.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.C_Value, Value = computation.CValue.ToString(), IndentDepth = indentDepth + 2 });

                if (computation.IsNot.HasValue)
                    comp.Properties.Add(new VtsProperty { Name = KeywordStrings.IsNot, Value = computation.IsNot.Value ? KeywordStrings.True : KeywordStrings.False, IndentDepth = indentDepth + 2 });

                c.Children.Add(comp);
            }

            return c;
        }

        private static void WriteConditionals(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject conditionals = new VtsObject { Name = KeywordStrings.Conditionals, IndentDepth = 1 };

            foreach (Conditional conditional in scenario.Conditionals)
            {
                conditionals.Children.Add(WriteConditional(conditional, 2));
            }

            cs.Children.Add(conditionals);
        }

        private static void WriteConditionalActions(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject conditionalActions = new VtsObject { Name = KeywordStrings.ConditionalActions, IndentDepth = 1 };

            foreach (ConditionalAction conditionalAction in scenario.ConditionalActions)
            {
                VtsObject ca = new VtsObject { Name = KeywordStrings.ConditionalAction, IndentDepth = 2 };
                ca.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = conditionalAction.Id.ToString(), IndentDepth = 3 });
                ca.Properties.Add(new VtsProperty { Name = KeywordStrings.Name, Value = conditionalAction.Name, IndentDepth = 3 });

                VtsObject bb = new VtsObject { Name = KeywordStrings.BaseBlock, IndentDepth = 3 };
                bb.Properties.Add(new VtsProperty { Name = KeywordStrings.BlockName, Value = conditionalAction.BaseBlock.BlockName, IndentDepth = 4 });
                bb.Properties.Add(new VtsProperty { Name = KeywordStrings.BlockId, Value = conditionalAction.BaseBlock.BlockId.ToString(), IndentDepth = 4 });

                bb.Children.Add(WriteConditional(conditionalAction.BaseBlock.Conditional, 4));
                bb.Children.Add(WriteEventInfo(conditionalAction.BaseBlock.Actions, 4, 1));

                foreach (Block elseIfBlock in conditionalAction.BaseBlock.ElseIfBlocks)
                {
                    VtsObject eib = new VtsObject { Name = KeywordStrings.ElseIf, IndentDepth = 4 };
                    eib.Properties.Add(new VtsProperty { Name = KeywordStrings.BlockName, Value = elseIfBlock.BlockName, IndentDepth = 5 });
                    eib.Properties.Add(new VtsProperty { Name = KeywordStrings.BlockId, Value = elseIfBlock.BlockId.ToString(), IndentDepth = 5 });

                    eib.Children.Add(WriteConditional(elseIfBlock.Conditional, 5));
                    eib.Children.Add(WriteEventInfo(elseIfBlock.Actions, 5, 1));
                    eib.Children.Add(WriteEventInfo(elseIfBlock.ElseActions, 5, 2));

                    bb.Children.Add(eib);
                }

                bb.Children.Add(WriteEventInfo(conditionalAction.BaseBlock.ElseActions, 4, 2));

                ca.Children.Add(bb);

                conditionalActions.Children.Add(ca);
            }

            cs.Children.Add(conditionalActions);
        }

        private static void WriteEventSequences(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject eventSequences = new VtsObject { Name = KeywordStrings.EventSequences, IndentDepth = 1 };

            foreach (Sequence sequence in scenario.EventSequences)
            {
                VtsObject s = new VtsObject { Name = KeywordStrings.Sequence, IndentDepth = 2 };
                s.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = sequence.Id.ToString(), IndentDepth = 3 });
                s.Properties.Add(new VtsProperty { Name = KeywordStrings.SequenceName, Value = sequence.SequenceName, IndentDepth = 3 });
                s.Properties.Add(new VtsProperty { Name = KeywordStrings.StartImmediately, Value = sequence.StartImmediately ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });
                s.Properties.Add(new VtsProperty { Name = KeywordStrings.WhileLoop, Value = sequence.WhileLoop ? KeywordStrings.True : KeywordStrings.False, IndentDepth = 3 });

                foreach (Event @event in sequence.Events)
                {
                    VtsObject e = new VtsObject { Name = KeywordStrings.Event, IndentDepth = 3 };

                    if (@event.Conditional.HasValue)
                        e.Properties.Add(new VtsProperty { Name = KeywordStrings.ConditionalProperty, Value = @event.Conditional.ToString(), IndentDepth = 4 });

                    e.Properties.Add(new VtsProperty { Name = KeywordStrings.Delay, Value = @event.Delay.ToString(), IndentDepth = 4 });
                    e.Properties.Add(new VtsProperty { Name = KeywordStrings.NodeName, Value = @event.NodeName, IndentDepth = 4 });

                    if (@event.ExitConditional.HasValue)
                        e.Properties.Add(new VtsProperty { Name = KeywordStrings.ExitConditional, Value = @event.ExitConditional.Value.ToString(), IndentDepth = 4 });

                    VtsObject ei = WriteEventInfo(@event.EventInfo, 4, 0);

                    e.Children.Add(ei);

                    s.Children.Add(e);
                }

                eventSequences.Children.Add(s);
            }

            cs.Children.Add(eventSequences);
        }

        private static void WriteBases(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject bases = new VtsObject { Name = KeywordStrings.Bases, IndentDepth = 1 };

            foreach (BaseInfo baseInfo in scenario.Bases)
            {
                VtsObject b = new VtsObject { Name = KeywordStrings.BaseInfo, IndentDepth = 2 };
                b.Properties.Add(new VtsProperty { Name = KeywordStrings.Id, Value = baseInfo.Id.ToString(), IndentDepth = 3 });
                b.Properties.Add(new VtsProperty { Name = KeywordStrings.OverrideBaseName, Value = baseInfo.OverrideBaseName, IndentDepth = 3 });
                b.Properties.Add(new VtsProperty { Name = KeywordStrings.BaseTeam, Value = baseInfo.BaseTeam, IndentDepth = 3 });

                bases.Children.Add(b);
            }

            cs.Children.Add(bases);
        }

        private static void WriteGlobalValues(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject globalValues = new VtsObject { Name = KeywordStrings.GlobalValues, IndentDepth = 1 };

            foreach (GlobalValue globalValue in scenario.GlobalValues)
            {
                VtsObject gv = new VtsObject { Name = KeywordStrings.GlobalValue, IndentDepth = 2 };
                gv.Properties.Add(new VtsProperty { Name = KeywordStrings.Data, Value = globalValue.ToString(), IndentDepth = 3 });

                globalValues.Children.Add(gv);
            }

            cs.Children.Add(globalValues);
        }

        private static void WriteBriefingNotes(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject briefing = new VtsObject { Name = KeywordStrings.Briefing, IndentDepth = 1 };

            foreach (BriefingNote briefingNote in scenario.BriefingNotes)
            {
                VtsObject bn = new VtsObject { Name = KeywordStrings.BriefingNote, IndentDepth = 2 };
                bn.Properties.Add(new VtsProperty { Name = KeywordStrings.Text, Value = briefingNote.Text, IndentDepth = 3 });
                bn.Properties.Add(new VtsProperty { Name = KeywordStrings.ImagePath, Value = briefingNote.ImagePath, IndentDepth = 3 });
                bn.Properties.Add(new VtsProperty { Name = KeywordStrings.AudioClipPath, Value = briefingNote.AudioClipPath, IndentDepth = 3 });

                briefing.Children.Add(bn);
            }

            cs.Children.Add(briefing);
        }

        private static void WriteResourceManifest(CustomScenario scenario, VtsCustomScenarioObject cs)
        {
            VtsObject resourceManifest = new VtsObject { Name = KeywordStrings.ResourceManifest, IndentDepth = 1 };

            foreach (Resource resource in scenario.ResourceManifest)
            {
                resourceManifest.Properties.Add(new VtsProperty { Name = resource.Index.ToString(), Value = resource.Path, IndentDepth = 2 });
            }

            cs.Children.Add(resourceManifest);
        }

        /// <summary>Writes the CustomScenario object to a VTS file. CustomScenario.File must be set.</summary>
        /// <param name="scenario">The CustomScenario object to write to the VTS file.</param>
        /// <returns>True if the VTS file was written, false if not (HasError will get set if an error occurred).</returns>
        /// <exception cref="ArgumentException">Occurs if the File property on the CustomScenario object is empty, null or consist of only white-space characters.</exception>
        public static bool WriteVtsFile(CustomScenario scenario)
        {
            if (scenario == null) return false;
            if (scenario.HasError) return false;
            if (string.IsNullOrWhiteSpace(scenario.File))
                throw new ArgumentException("scenario File property cannot be empty, null or consist of white-space characters only.");

            try
            {
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

                if (DiagnosticOptions.OutputReadWriteTimes)
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
