using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Type")]
[UnitFriendlyName("GUIEvent.Get Type")]
[UnitUsage(typeof(EventType), HideExpressionInActionsList = true)]
public class JLGUIEventGetType : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.type;
    }
}
