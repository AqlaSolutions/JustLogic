/*#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnFailedToConnect : IEventDescription
    {
        public Type RequiredEventHandler { get { return typeof(JustLogicEventHandlerLite); } }
        public string Name { get { return "OnFailedToConnect"; } }
        readonly static EventArguments Args = new EventArguments(new[] { new KeyValuePair<string, Type>("error", typeof(NetworkConnectionError)) });
        public EventArguments Arguments { get { return Args; } }
    }
}
#endif
*/