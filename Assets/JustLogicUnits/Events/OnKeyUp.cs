using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnKeyUp: IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandler"; } }
        public string Name { get { return "OnKeyUp"; } }
        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("key", typeof(KeyCode)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}
