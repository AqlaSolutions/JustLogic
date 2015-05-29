using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Axis")]
[UnitFriendlyName("Get Axis")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLInputGetAxis : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression AxisName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetAxis(AxisName.GetResult<System.String>(context));
    }
}
