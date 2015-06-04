using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Current")]
[UnitMenu("Value/Current GUI Event")]
[UnitFriendlyName("GUIEvent.Get Current")]
[UnitUsage(typeof(Event), HideExpressionInActionsList = true)]
public class JLGUIEventGetCurrent : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Event.current;
    }
}
