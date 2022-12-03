namespace VTS.Data.Runtime
{
    /// <summary>Represents a block in a conditional action (this can be the BASE_BLOCK or ELSE_IF blocks inside the BASE_BLOCK block).</summary>
    public class Block : ICloneable
    {
        #region Properties

        public EventInfo Actions { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public Conditional Conditional { get; set; }
        public EventInfo ElseActions { get; set; }
        public List<Block> ElseIfBlocks { get; set; } = new List<Block>();

        // can be a ConditionalAction or another Block (ElseIfBlocks)
        public object Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Block"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Block object.</returns>
        public Block Clone()
        {
            return new Block
            {
                Actions = Actions.Clone(),
                BlockId = BlockId,
                BlockName = BlockName,
                Conditional = Conditional.Clone(),
                ElseActions = ElseActions.Clone(),
                ElseIfBlocks = ElseIfBlocks.Select(x => x.Clone()).ToList(),
                Parent = Parent
            };
        }

        #endregion
    }
}
