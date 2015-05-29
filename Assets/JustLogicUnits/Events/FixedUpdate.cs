#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct FixedUpdate : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "FixedUpdate"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
