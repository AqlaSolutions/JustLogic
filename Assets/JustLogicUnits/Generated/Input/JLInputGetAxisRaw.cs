using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Axis Raw")]
[UnitFriendlyName("Get Axis Raw")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLInputGetAxisRaw : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression AxisName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetAxisRaw(AxisName.GetResult<System.String>(context));
    }
}
