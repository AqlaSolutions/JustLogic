using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Button")]
[UnitFriendlyName("GUIEvent.Get Button")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLGUIEventGetButton : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.button;
    }
}
