using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Command")]
[UnitFriendlyName("GUIEvent.Get Command")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGUIEventGetCommand : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.command;
    }
}
