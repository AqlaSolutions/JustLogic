using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Range (float)")]
[UnitFriendlyName("Random.Range")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRandomRange : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Min;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Max;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Random.Range(Min.GetResult<System.Single>(context), Max.GetResult<System.Single>(context));
    }
}
