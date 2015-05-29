/*#if !JUSTLOGIC_FREE
using System;

namespace JustLogic.Core.Events
{
    public struct OnConnectedToServer : IEventDescription
    {
        public Type RequiredEventHandler { get { return typeof(JustLogicEventHandlerLite); } }
        public string Name { get { return "OnConnectedToServer"; } }
        public EventArguments Arguments { get { return EventArguments.None; } }
    }
}
#endif
*/