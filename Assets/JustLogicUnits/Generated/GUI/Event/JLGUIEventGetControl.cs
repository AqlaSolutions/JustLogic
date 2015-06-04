using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Control")]
[UnitFriendlyName("GUIEvent.Get Control")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGUIEventGetControl : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.control;
    }
}
