namespace VTS.Data
{
    /// <summary>Represents a block in a conditional action (this can be the BASE_BLOCK or ELSE_IF blocks inside the BASE_BLOCK block).</summary>
    public class Block
    {
        #region Properties

        public EventInfo Actions { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public Conditional Conditional { get; set; }
        public EventInfo ElseActions { get; set; }
        public List<Block> ElseIfBlocks { get; set; } = new List<Block>();

        #endregion
    }
}
