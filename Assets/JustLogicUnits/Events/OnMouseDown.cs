#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnMouseDown : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerMouse"; } }
        public string Name { get { return "OnMouseDown"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
