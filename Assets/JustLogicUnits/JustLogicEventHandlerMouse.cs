using System;
using System.Collections.Generic;
using JustLogic.Core;
using JustLogic.Core.Events;

using UnityEngine;

[ExecuteInEditMode]
//[AddComponentMenu("Just Logic/JL Event Handler +Mouse")]
public class JustLogicEventHandlerMouse : JustLogicEventHandler
{
#if !JUSTLOGIC_FREE
    protected void OnMouseDown()
    {
        Trigger(new OnMouseDown());
    }

    protected void OnMouseDrag()
    {
        Trigger(new OnMouseDrag());
    }

    protected void OnMouseEnter()
    {
        Trigger(new OnMouseEnter());
    }

    protected void OnMouseExit()
    {
        Trigger(new OnMouseExit());
    }

    protected void OnMouseOver()
    {
        Trigger(new OnMouseOver());
    }

    protected void OnMouseUp()
    {
        Trigger(new OnMouseUp());
    }
#endif
}
