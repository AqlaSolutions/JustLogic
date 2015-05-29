using System;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class EnumTypeDrawer : LongListDrawer
    {
        public EnumTypeDrawer()
            : base(new LongListSelector(DrawersLibrary.EnumList, DrawersLibrary.EnumListShort, filter: "UnityEngine."))
        {
        }

        public override string Label { get { return "Type: "; } }
    }
}