#if !JUSTLOGIC_FREE

using System;
using System.Collections.Generic;
using JustLogic.Core;
using JustLogic.Core.Events;
using UnityEngine;
using Object = UnityEngine.Object;

/// <tocexclude />
public abstract class JustLogicTimerBase : JustLogicBehaviorBase
{
    public float Interval;
    public bool Once;
    public Object Receiver;
    [NonSerialized]
    float _spent;

    protected void Reset()
    {
        Receiver = gameObject;
    }

    protected void Update()
    {
        if ((_spent += Time.deltaTime) > Interval)
        {
            _spent = 0f;
            if (Once) enabled = false;
            var jlscript = Receiver as JustLogicScriptBase;
            if (jlscript)
                jlscript.StartExecutionByEvent(new EventData(new OnJLTimerTick(), new[] { this }, null, 0));
            else
            {
                var script = Receiver as MonoBehaviour;
                if (script)
                    script.SendMessage("OnJLTimerTick", this, SendMessageOptions.DontRequireReceiver);
                else
                {
                    var go = Receiver as GameObject;
                    if (go)
                        go.SendMessage("OnJLTimerTick", this, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}

#endif
