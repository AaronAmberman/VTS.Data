namespace VTS.Data.Runtime
{
    public class ObjectiveFields : ICloneable
    {
        #region Properties

        public Conditional FailConditional { get; set; }
        public Conditional SuccessConditional { get; set; }
        public float? Radius { get; set; }
        public List<UnitSpawner> Targets { get; set; } = new List<UnitSpawner>();
        public int? MinRequired { get; set; }
        public int? PerUnitReward { get; set; }
        public int? FullCompletionBonus { get; set; }
        public float? UnloadRadius { get; set; }
        public Waypoint DropoffRallyPoint { get; set; }
        public float? TriggerRadius { get; set; }
        public bool? SphericalRadius { get; set; }
        public UnitSpawner TargetUnit { get; set; }
        public float? FuelLevel { get; set; }
        public string CompletionMode { get; set; }
        public UnitSpawner Target { get; set; }

        public Objective Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="ObjectiveFields"/> with all the same values as this instance.</summary>
        /// <returns>A cloned ObjectiveFields object.</returns>
        public ObjectiveFields Clone()
        {
            return new ObjectiveFields
            {
                FailConditional = FailConditional?.Clone(),
                SuccessConditional = SuccessConditional?.Clone(),
                Radius = Radius,
                Targets = Targets.Select(x => x.Clone()).ToList(),
                MinRequired = MinRequired,
                PerUnitReward = PerUnitReward,
                FullCompletionBonus = FullCompletionBonus,
                UnloadRadius = UnloadRadius,
                DropoffRallyPoint = DropoffRallyPoint?.Clone(),
                TriggerRadius = TriggerRadius,
                SphericalRadius = SphericalRadius,
                TargetUnit = TargetUnit?.Clone(),
                FuelLevel = FuelLevel,
                CompletionMode = CompletionMode,
                Target = Target?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
