namespace VTS.Data
{
    public class ObjectiveFields
    {
        #region Properties

        public int? FailConditional { get; set; }
        public int? SuccessConditional { get; set; }
        public double? Radius { get; set; }
        public string Targets { get; set; }
        public int? MinRequired { get; set; }
        public int? PerUnitReward { get; set; }
        public int? FullCompletionBonus { get; set; }
        public int? UnloadRadius { get; set; }
        public int? DropoffRallyPoint { get; set; }
        public double? TriggerRadius { get; set; }
        public bool? SphericalRadius { get; set; }
        public int? TargetUnit { get; set; }
        public double? FuelLevel { get; set; }
        public string CompletionMode { get; set; }

        #endregion
    }
}
