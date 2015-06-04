using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Math/MoveTowards")]
[UnitFriendlyName("MoveTowards")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLMathMoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.MoveTowards(Current.GetResult<System.Single>(context), Target.GetResult<System.Single>(context), MaxDelta.GetResult<System.Single>(context));
    }
}
