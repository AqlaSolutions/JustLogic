/*#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnServerInitialized : IEventDescription
    {
        public Type RequiredEventHandler { get { return typeof(JustLogicEventHandlerLite); } }
        public string Name { get { return "OnServerInitialized"; } }
        public EventArguments Arguments { get { return EventArguments.None; } }
    }
}
#endif
*/