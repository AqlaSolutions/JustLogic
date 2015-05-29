#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnMouseEnter : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerMouse"; } }
        public string Name { get { return "OnMouseEnter"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
