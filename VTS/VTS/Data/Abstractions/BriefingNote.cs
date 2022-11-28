namespace VTS.Data.Abstractions
{
    /// <summary>Represents a briefing note in VTOL VR.</summary>
    public class BriefingNote : ICloneable
    {
        #region Properties

        public string AudioClipPath { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="BriefingNote"/> with all the same values as this instance.</summary>
        /// <returns>A cloned BriefingNote object.</returns>
        public BriefingNote Clone()
        {
            return new BriefingNote
            {
                AudioClipPath = AudioClipPath,
                ImagePath = ImagePath,
                Text = Text
            };
        }

        #endregion
    }
}
