using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Pressure")]
[UnitFriendlyName("GUIEvent.Get Pressure")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLGUIEventGetPressure : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.pressure;
    }
}
