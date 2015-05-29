#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnMouseUp : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerMouse"; } }
        public string Name { get { return "OnMouseUp"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
