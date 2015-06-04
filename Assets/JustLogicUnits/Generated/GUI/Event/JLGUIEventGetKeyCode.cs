using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Key Code")]
[UnitFriendlyName("GUIEvent.Get Key Code")]
[UnitUsage(typeof(KeyCode), HideExpressionInActionsList = true)]
public class JLGUIEventGetKeyCode : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.keyCode;
    }
}
