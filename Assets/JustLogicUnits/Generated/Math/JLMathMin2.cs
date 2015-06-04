using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Min (int[])")]
[UnitFriendlyName("Min (int[])")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathMin2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Min(Values.GetResult<System.Int32>(context));
    }
}
