namespace VTS.Data
{
    /// <summary>Represents a global value in VTOL VR.</summary>
    public class GlobalValue
    {
        #region Properties

        //public string Data { get; set; } // data = 1;MyValue;My value description;1234;
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        #endregion
    }
}
