using System;
using System.Collections.Generic;
using JustLogic.Core;
using JustLogic.Core.Events;

using UnityEngine;

[ExecuteInEditMode]
//[AddComponentMenu("Just Logic/JL Event Handler")]
public class JustLogicEventHandler : JustLogicEventHandlerLite
{
    [NonSerialized]
    List<KeyCode> _downKeys;

    protected override void Awake()
    {
        _downKeys = new List<KeyCode>();
        base.Awake();
    }

    protected void OnGUI()
    {
        if (!Application.isPlaying) return;
#if !JUSTLOGIC_FREE
        Trigger(new OnGUI());
#endif
        if (Event.current.type == EventType.KeyDown)
        {
            if (!_downKeys.Contains(Event.current.keyCode))
            {
                _downKeys.Add(Event.current.keyCode);
#if !JUSTLOGIC_FREE
                Trigger(new OnKeyDown(), Event.current.keyCode);
#endif
            }
        }
        else if (Event.current.type == EventType.KeyUp)
        {
            if (_downKeys.Remove(Event.current.keyCode))
                Trigger(new OnKeyUp(), Event.current.keyCode);
        }
    }
}
