using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnCollisionStay : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnCollisionStay"; } }
        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("collisionInfo", typeof(Collision)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}