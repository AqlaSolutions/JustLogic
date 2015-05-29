#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnMouseDrag : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerMouse"; } }
        public string Name { get { return "OnMouseDrag"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
