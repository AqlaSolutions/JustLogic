#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnKeyDown : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandler"; } }
        public string Name { get { return "OnKeyDown"; } }
        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("key", typeof(KeyCode)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}
#endif
