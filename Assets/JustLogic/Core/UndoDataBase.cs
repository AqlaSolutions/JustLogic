using System;
using System.Collections.Generic;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class UndoDataBase
    {
        public object CurrentSnapshot { get; set; }

        public List<object> Snapshots { get { return _snapshots; } }

        private readonly List<object> _snapshots = new List<object>();

        public int UndoIndex;
        
        public int UndoPersistentIndex { get; set; }
    }
}