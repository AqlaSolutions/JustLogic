using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Modifiers")]
[UnitFriendlyName("GUIEvent.Get Modifiers")]
[UnitUsage(typeof(EventModifiers), HideExpressionInActionsList = true)]
public class JLGUIEventGetModifiers : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.modifiers;
    }
}
