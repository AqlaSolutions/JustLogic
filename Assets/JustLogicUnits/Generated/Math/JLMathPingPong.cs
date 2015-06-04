using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/PingPong")]
[UnitFriendlyName("PingPong")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathPingPong : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.PingPong(T.GetResult<System.Single>(context), Length.GetResult<System.Single>(context));
    }
}
