using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Keyboard Event")]
[UnitFriendlyName("GUIEvent.Keyboard Event")]
[UnitUsage(typeof(UnityEngine.Event), HideExpressionInActionsList = true)]
public class JLGUIEventKeyboardEvent : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Key;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Event.KeyboardEvent(Key.GetResult<System.String>(context));
    }
}
