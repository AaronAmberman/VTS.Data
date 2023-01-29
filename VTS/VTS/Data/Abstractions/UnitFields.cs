using VTS.Data.Diagnostics;

namespace VTS.Data.Abstractions
{
    /// <summary>Represents the unit fields on a unit.</summary>
    public class UnitFields : ICloneable
    {
        #region Properties

        /// <summary>Gets the list of unit fields to write to the VTS file for a type.</summary>
        /// <remarks>The units are from the unitID property on the UnitSpawner in the VTS file.</remarks>
        public static IReadOnlyList<UnitUnitFieldGrouping> UnitAndUnitFieldsMap { get; } = new List<UnitUnitFieldGrouping>
        {
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AEW-50"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "defaultRadarEnabled", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AIUCAV", "ASF-30", "ASF-33", "ASF-58"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "defaultRadarEnabled", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "equips"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "ABomberAI", "AV-42CAI"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "voiceProfile", "playerCommandsMode", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "equips"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "E-4"
                },
                UnitFields = new List<string>
                {
                    "awacsVoiceProfile", "commsEnabled", "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "defaultRadarEnabled", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "F-45A AI", "FA-26B AI"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "voiceProfile", "playerCommandsMode", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "defaultRadarEnabled", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "equips"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "MQ-31"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "equips"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "EBomberAI", "GAV-25",
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "equips"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "KC-49",
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "initialSpeed", "defaultNavSpeed", "defaultOrbitPoint", "defaultPath", "orbitAltitude", "fuel", "autoRefuel", "autoRTB", "rtbDestination", "parkedStartMode", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AlliedAAShip", "AlliedCarrier"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "defaultWaypoint", "defaultPath", "hullNumber", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "carrierSpawns"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "EscortCruiser"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "defaultWaypoint", "defaultPath", "hullNumber", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "carrierSpawns"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AlliedBackstopSAM", "PatriotLauncher", "SamBattery1"
                },
                UnitFields = new List<string>
                {
                    "radarUnits", "allowReload", "reloadTime", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AlliedEWRadar", "BSTOPRadar", "bunker1", "bunker2", "PatRadarTrailer", "SamFCR", "SamFCR2", "staticAAA-20x2", "staticCIWS"
                },
                UnitFields = new List<string>
                {
                    "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "alliedCylinderTent", "cylinderTent"
                },
                UnitFields = new List<string>
                {
                    "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "combatTarget", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "alliedMBT1", "enemyMBT1", "SAAW"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "moveSpeed", "behavior", "defaultPath", "waypoint", "stopToEngage", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AlliedSoldier", "AlliedSoldierMANPAD", "EnemySoldier", "EnemySoldierMANPAD"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "behavior", "defaultPath", "waypoint", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "ARocketTruck", "ERocketTruck"
                },
                UnitFields = new List<string>
                {
                    "defaultShotsPerSalvo", "rippleRate", "allowReload", "reloadTime", "unitGroup", "moveSpeed", "behavior", "defaultPath", "waypoint", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "Artillery", "IRAPC", "MAD-4Radar", "PhallanxTruck", "SRADTruck", "WatchmanTruck"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "moveSpeed", "behavior", "defaultPath", "waypoint", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "MAD-4Launcher", "SLAIM120Truck"
                },
                UnitFields = new List<string>
                {
                    "radarUnits", "allowReload", "reloadTime", "unitGroup", "moveSpeed", "behavior", "defaultPath", "waypoint", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "AlliedRearmRefuelPoint"
                },
                UnitFields = new List<string>
                {
                    "spawnOnStart", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "PlayerSpawn"
                },
                UnitFields = new List<string>
                {
                    "startMode", "initialSpeed", "unitGroup", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "DroneCarrier", "DroneGunBoat", "DroneGunBoatRocket", "DroneMissileCruiser", "ESuperMissileCruiser", "MineBoat"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "defaultWaypoint", "defaultPath", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage"
                }
            },
            new UnitUnitFieldGrouping
            {
                Units = new List<string>
                {
                    "EnemyCarrier"
                },
                UnitFields = new List<string>
                {
                    "unitGroup", "defaultBehavior", "defaultWaypoint", "defaultPath", "engageEnemies", "detectionMode", "spawnOnStart", "invincible", "respawnable", "receiveFriendlyDamage", "carrierSpawns"
                }
            }
        };

        public bool AllowReload { get; set; }
        public bool AutoRefuel { get; set; }
        public bool AutoReturnToBase { get; set; }  
        public string AwacsVoiceProfile { get; set; }
        public string Behavior { get; set; }
        public string CarrierSpawns { get; set; } // Value:0:87;1:88;2:89;3:90;4:91;5:93;6:94;7:95;8:92;
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
        public string ReturnToBaseDestination { get; set; }
        public bool SpawnOnStart { get; set; }
        public string StartMode { get; set; }
        public bool StopToEngage { get; set; }
        public string UnitGroup { get; set; }
        public string VoiceProfile { get; set; }
        public string Waypoint { get; set; }

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
                Waypoint = Waypoint
            };
        }

        public static IReadOnlyList<string> GetUnitFieldsForUnitType(string unitType)
        {
            foreach (UnitUnitFieldGrouping unitUnitFieldGrouping in UnitAndUnitFieldsMap)
            {
                foreach (string unit in unitUnitFieldGrouping.Units)
                {
                    if (unit == unitType)
                        return unitUnitFieldGrouping.UnitFields;
                }
            }

            return new List<string>();
        }

        #endregion
    }
}
