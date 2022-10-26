namespace VTS.Data
{
    public class ObjectiveFields
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
    }
}
