using JustLogic.Core;
using UnityEngine;

[UnitMenu("Math/Lerp (float)")]
[UnitUsage(typeof(float), HideExpressionInActionsList = true)]
public class JLLerpFloat : JLExpression
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression From;
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression To;
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression LerpFactor;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Mathf.Lerp(From.GetResult<float>(context), To.GetResult<float>(context), LerpFactor.GetResult<float>(context));
    }
}
