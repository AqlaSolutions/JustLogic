#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace JustLogic.Core.Events
{
    public struct OnRenderImage : IEventDescription
    {
        public string RequiredEventHandler { get { return "JustLogicEventHandlerLite"; } }
        public string Name { get { return "OnRenderImage"; } }

        readonly static EventDescriptionArguments Args = new EventDescriptionArguments(new[] { new KeyValuePair<string, Type>("source", typeof(RenderTexture)), new KeyValuePair<string, Type>("destination", typeof(RenderTexture)) });
        public EventDescriptionArguments Arguments { get { return Args; } }
    }
}
#endif
