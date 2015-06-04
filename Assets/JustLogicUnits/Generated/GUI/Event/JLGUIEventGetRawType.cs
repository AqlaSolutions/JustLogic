using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Raw Type")]
[UnitFriendlyName("GUIEvent.Get Raw Type")]
[UnitUsage(typeof(EventType), HideExpressionInActionsList = true)]
public class JLGUIEventGetRawType : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.rawType;
    }
}
