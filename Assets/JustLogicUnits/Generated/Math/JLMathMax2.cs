using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/Max (int[])")]
[UnitFriendlyName("Max (int[])")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLMathMax2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Max(Values.GetResult<System.Int32>(context));
    }
}
