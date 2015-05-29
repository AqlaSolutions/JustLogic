#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnBecameVisible : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnBecameVisible"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
