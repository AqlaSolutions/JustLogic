using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Button")]
[UnitFriendlyName("GUIEvent.Get Button")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLGUIEventGetButton : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.button;
    }
}
