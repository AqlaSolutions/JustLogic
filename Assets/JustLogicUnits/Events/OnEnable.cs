#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnEnable : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnEnable"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
