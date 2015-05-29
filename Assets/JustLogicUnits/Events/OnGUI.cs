#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnGUI : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandler"; } }
        public string Name { get { return "OnGUI"; } }
        public EventDescriptionArguments Arguments { get { return EventDescriptionArguments.None; } }
    }
}
#endif
