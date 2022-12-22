using VTS.Data.Diagnostics;

namespace VTS.Data.Runtime
{
    /// <summary>Represents the unit fields on a unit.</summary>
    public class UnitFields : ICloneable
    {
        #region Properties

        public bool AllowReload { get; set; }
        public bool AutoRefuel { get; set; }
        public bool AutoReturnToBase { get; set; }  
        public string AwacsVoiceProfile { get; set; }
        public string Behavior { get; set; }
        public List<Tuple<int, UnitSpawner>> CarrierSpawns { get; set; } = new List<Tuple<int, UnitSpawner>>(); // Value:0:87;1:88;2:89;3:90;4:91;5:93;6:94;7:95;8:92;
        public bool CombatTarget { get; set; }
        public bool CommsEnabled { get; set; }
        public string DefaultBehavior { get; set; }
        public int DefaultNavSpeed { get; set; }
        public string DefaultOrbitPoint { get; set; }
        public string DefaultPath { get; set; }
        public bool DefaultRadarEnabled { get; set; }
        public int DefaultShotsPerSalvo { get; set; }
        public string DefaultWaypoint { get; set; }
        public string DetectionMode { get; set; }
        public bool EngageEnemies { get; set; }
        public string Equips { get; set; } // Value:gau-8;hellfirex4;sidewinderx3;hellfirex4;sidewinderx3;gbu39x4u;gbu39x4u;
        public int Fuel { get; set; }
        public int HullNumber { get; set; }
        public int InitialSpeed { get; set; }
        public bool Invincible { get; set; }
        public string MoveSpeed { get; set; }
        public float OrbitAltitude { get; set; }
        public string ParkedStartMode { get; set; }
        public string PlayerCommandsMode { get; set; }
        public string RadarUnits { get; set; }
        public int RippleRate { get; set; }
        public bool ReceiveFriendlyDamage { get; set; }
        public int ReloadTime { get; set; }
        public bool Respawnable { get; set; }
        public object ReturnToBaseDestination { get; set; } // Value will be either "", map:# (this is a base), unit:# (this will be a unit)
        public bool SpawnOnStart { get; set; }
        public string StartMode { get; set; }
        public bool StopToEngage { get; set; }
        public string UnitGroup { get; set; }
        public string VoiceProfile { get; set; }
        public Waypoint Waypoint { get; set; }

        public UnitSpawner Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitFields"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitFields object.</returns>
        public UnitFields Clone()
        {
            return new UnitFields
            {
                AllowReload = AllowReload,
                AutoRefuel = AutoRefuel,
                AutoReturnToBase = AutoReturnToBase,
                AwacsVoiceProfile = AwacsVoiceProfile,
                Behavior = Behavior,
                CarrierSpawns = CarrierSpawns,
                CombatTarget = CombatTarget,
                CommsEnabled = CommsEnabled,
                DefaultBehavior = DefaultBehavior,
                DefaultNavSpeed = DefaultNavSpeed,
                DefaultOrbitPoint = DefaultOrbitPoint,
                DefaultPath = DefaultPath,
                DefaultRadarEnabled = DefaultRadarEnabled,
                DefaultShotsPerSalvo = DefaultShotsPerSalvo,
                DefaultWaypoint = DefaultWaypoint,
                DetectionMode = DetectionMode,
                EngageEnemies = EngageEnemies,
                Equips = Equips,
                Fuel = Fuel,
                HullNumber = HullNumber,
                InitialSpeed = InitialSpeed,
                Invincible = Invincible,
                MoveSpeed = MoveSpeed,
                OrbitAltitude = OrbitAltitude,
                ParkedStartMode = ParkedStartMode,
                PlayerCommandsMode = PlayerCommandsMode,
                RadarUnits = RadarUnits,
                Respawnable = Respawnable,
                RippleRate = RippleRate,
                ReceiveFriendlyDamage = ReceiveFriendlyDamage,
                ReloadTime = ReloadTime,
                ReturnToBaseDestination = ReturnToBaseDestination,
                SpawnOnStart = SpawnOnStart,
                StartMode = StartMode,
                StopToEngage = StopToEngage,
                UnitGroup = UnitGroup,
                VoiceProfile = VoiceProfile,
                Waypoint = Waypoint,
                Parent = Parent
            };
        }

        #endregion
    }
}
