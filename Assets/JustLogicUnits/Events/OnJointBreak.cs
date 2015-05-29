#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnJointBreak : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnJointBreak"; } }
        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("breakForce", typeof(float)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}
#endif
