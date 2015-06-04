using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Range (int)")]
[UnitFriendlyName("Random.Range")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLRandomRange2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Min;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Max;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Random.Range(Min.GetResult<System.Int32>(context), Max.GetResult<System.Int32>(context));
    }
}
