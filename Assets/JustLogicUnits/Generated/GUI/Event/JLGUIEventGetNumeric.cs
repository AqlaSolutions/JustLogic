using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Numeric")]
[UnitFriendlyName("GUIEvent.Get Numeric")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGUIEventGetNumeric : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.numeric;
    }
}
