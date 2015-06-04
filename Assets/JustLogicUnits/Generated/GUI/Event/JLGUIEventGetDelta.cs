using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Delta")]
[UnitFriendlyName("GUIEvent.Get Delta")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLGUIEventGetDelta : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.delta;
    }
}
