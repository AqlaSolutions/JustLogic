using System;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class TypeDrawer : LongListDrawer
    {
        public TypeDrawer()
            : base(new LongListSelector(DrawersLibrary.TypesListShort, DrawersLibrary.TypesList, filter: "UnityEngine."))
        {
        }

        public override string Label { get { return "Type: "; } }
    }
}