using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Command Name")]
[UnitFriendlyName("GUIEvent.Get Command Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLGUIEventGetCommandName : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.commandName;
    }
}
