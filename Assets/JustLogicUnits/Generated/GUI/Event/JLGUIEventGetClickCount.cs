using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Click Count")]
[UnitFriendlyName("GUIEvent.Get Click Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLGUIEventGetClickCount : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.clickCount;
    }
}
