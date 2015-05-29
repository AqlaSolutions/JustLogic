using System;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class EventDrawer : LongListDrawer
    {
        public EventDrawer()
            : base(new LongListSelector(DrawersLibrary.EventsListShort, DrawersLibrary.EventsList, displayCurrentFullValue: false))
        {

        }

        public override string Label { get { return "Event: "; } }
    }
}