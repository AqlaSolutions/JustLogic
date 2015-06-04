using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Mouse Position")]
[UnitFriendlyName("GUIEvent.Get Mouse Position")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLGUIEventGetMousePosition : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.mousePosition;
    }
}
