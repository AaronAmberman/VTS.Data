namespace VTS.Data
{
    /// <summary>Represents a block in a conditional action (this can be the BASE_BLOCK or ELSE_IF blocks inside the BASE_BLOCK block).</summary>
    public class Block
    {
        #region Properties

        public List<EventInfo> Actions { get; set; } = new List<EventInfo>();
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public Conditional Conditional { get; set; }
        public List<EventInfo> ElseActions { get; set; } = new List<EventInfo>();
        public List<Block> ElseIfBlocks { get; set; } = new List<Block>();

        #endregion
    }
}
