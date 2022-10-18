namespace VTS.Data
{
    /// <summary>Represents the unit fields on a unit.</summary>
    public class UnitFields
    {
        #region Properties

        public bool? AllowReload { get; set; }
        public bool? AutoRefuel { get; set; }
        public bool? AutoReturnToBase { get; set; }  
        public string AwacsVoiceProfile { get; set; }
        public string Behavior { get; set; }
        public string CarrierSpawns { get; set; } // Value:0:87;1:88;2:89;3:90;4:91;5:93;6:94;7:95;8:92;
        public bool? CombatTarget { get; set; }
        public bool? CommsEnabled { get; set; }
        public string DefaultBehavior { get; set; }
        public int? DefaultNavSpeed { get; set; }
        public string DefaultOrbitPoint { get; set; }
        public string DefaultPath { get; set; }
        public bool? DefaultRadarEnabled { get; set; }
        public int? DefaultShotsPerSalvo { get; set; }
        public string DefaultWaypoint { get; set; }
        public string DetectionMode { get; set; }
        public bool? EngageEnemies { get; set; }
        public string Equips { get; set; } // Value:gau-8;hellfirex4;sidewinderx3;hellfirex4;sidewinderx3;gbu39x4u;gbu39x4u;
        public int? Fuel { get; set; }
        public int? HullNumber { get; set; }
        public int? InitialSpeed { get; set; }
        public bool? Invincible { get; set; }
        public string MoveSpeed { get; set; }
        public int? OrbitAltitude { get; set; }
        public string ParkedStartMode { get; set; }
        public string PlayerCommandsMode { get; set; }
        public string RadarUnits { get; set; }
        public int? RippleRate { get; set; }
        public bool? ReceiveFriendlyDamage { get; set; }
        public int? ReloadTime { get; set; }
        public string ReturnToBaseDestination { get; set; }
        public bool? SpawnOnStart { get; set; }
        public string StartMode { get; set; }
        public bool? StopToEngage { get; set; }
        public string UnitGroup { get; set; }
        public string VoiceProfile { get; set; }
        public string Waypoint { get; set; }

        #endregion
    }
}
