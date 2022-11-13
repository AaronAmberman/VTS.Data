namespace VTS.Data
{
    public class ObjectiveFields : ICloneable
    {
        #region Properties

        public int? FailConditional { get; set; }
        public int? SuccessConditional { get; set; }
        public float? Radius { get; set; }
        public string Targets { get; set; }
        public int? MinRequired { get; set; }
        public int? PerUnitReward { get; set; }
        public int? FullCompletionBonus { get; set; }
        public float? UnloadRadius { get; set; }
        public int? DropoffRallyPoint { get; set; }
        public float? TriggerRadius { get; set; }
        public bool? SphericalRadius { get; set; }
        public int? TargetUnit { get; set; }
        public float? FuelLevel { get; set; }
        public string CompletionMode { get; set; }

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
                FailConditional = FailConditional,
                SuccessConditional = SuccessConditional,
                Radius = Radius,
                Targets = Targets,
                MinRequired = MinRequired,
                PerUnitReward = PerUnitReward,
                FullCompletionBonus = FullCompletionBonus,
                UnloadRadius = UnloadRadius,
                DropoffRallyPoint = DropoffRallyPoint,
                TriggerRadius = TriggerRadius,
                SphericalRadius = SphericalRadius,
                TargetUnit = TargetUnit,
                FuelLevel = FuelLevel,
                CompletionMode = CompletionMode
            };
        }

        #endregion
    }
}
