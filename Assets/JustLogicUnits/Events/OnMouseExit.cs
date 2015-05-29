#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnMouseExit : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerMouse"; } }
        public string Name { get { return "OnMouseExit"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
