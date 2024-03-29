﻿namespace VTS.Data.Runtime
{
    /// <summary>Represents an event sequence in VTOL VR.</summary>
    public class Sequence : ICloneable
    {
        #region Properties

        public List<Event> Events { get; set; } = new List<Event>();
        public int Id { get; set; }
        public string SequenceName { get; set; }
        public bool StartImmediately { get; set; }
        public bool WhileLoop { get; set; }

        public CustomScenario Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="Sequence"/> with all the same values as this instance.</summary>
        /// <returns>A cloned Sequence object.</returns>
        public Sequence Clone()
        {
            return new Sequence
            {
                Events = Events.Select(x => x.Clone()).ToList(),
                Id = Id,
                SequenceName = SequenceName,
                StartImmediately = StartImmediately,
                WhileLoop = WhileLoop,
                Parent = Parent
            };
        }

        #endregion
    }
}
