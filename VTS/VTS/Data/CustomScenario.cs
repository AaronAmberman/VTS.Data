using VTS.Data.Raw;

namespace VTS.Data
{
    /// <summary>A managed wrapper for the VTS file.</summary>
    public class CustomScenario
    {
        #region Fields

        #endregion

        #region Properties

        public string AllowedEquips { get; set; }
        public string BaseBudget { get; set; }
        public string CampaignId { get; set; }
        public int CampaignOrderIndex { get; set; }
        public bool EquipsConfigurable { get; set; }
        public string EnvironmentName { get; set; }
        public string ForceEquips { get; set; }
        public bool ForcedEquips { get; set; }
        public string GameVersion { get; set; }
        public bool IsTraining { get; set; }
        public string MapId { get; set; }
        public bool Multiplayer { get; set; }
        public string NormalForcedFuel { get; set; }
        public int QuickSaveLimit { get; set; }
        public string QuickSaveMode { get; set; }
        public string RefuelWaypointId { get; set; }
        public string ReturnToBaseWaypointId { get; set; }
        public string ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDescription { get; set; }
        public bool SelectableEnvironment { get; set; }
        public string Vehicle { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="CustomScenario"/> class.</summary>
        /// <param name="scenario">The raw scenario object to read data from.</param>
        /// <exception cref="TypeInitializationException">Occurs if an exception is thrown while reading the VTS custom scenario object.</exception>
        public CustomScenario(VtsCustomScenarioObject scenario)
        {
            try
            {
                ReadInVtsCustomScenarioObject(scenario);
            }
            catch (Exception ex)
            {
                throw new TypeInitializationException("VTS.Data.CustomScenario", ex);
            }
        }

        #endregion

        #region Methods

        private void ReadInVtsCustomScenarioObject(VtsCustomScenarioObject scenario)
        {

        }

        #endregion
    }
}
