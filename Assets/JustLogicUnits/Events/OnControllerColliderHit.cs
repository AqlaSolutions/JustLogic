#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnControllerColliderHit : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnControllerColliderHit"; } }
        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("OnControllerColliderHit", typeof(ControllerColliderHit)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}
#endif
