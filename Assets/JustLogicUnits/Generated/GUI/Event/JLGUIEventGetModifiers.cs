using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Modifiers")]
[UnitFriendlyName("GUIEvent.Get Modifiers")]
[UnitUsage(typeof(UnityEngine.EventModifiers), HideExpressionInActionsList = true)]
public class JLGUIEventGetModifiers : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.modifiers;
    }
}
