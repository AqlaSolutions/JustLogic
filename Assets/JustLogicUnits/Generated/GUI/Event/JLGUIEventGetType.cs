using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Type")]
[UnitFriendlyName("GUIEvent.Get Type")]
[UnitUsage(typeof(UnityEngine.EventType), HideExpressionInActionsList = true)]
public class JLGUIEventGetType : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.type;
    }
}
