using JustLogic.Core;
using UnityEngine;

[UnitMenu("Math/Lerp (Vector3)")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLLerpVector3 : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression From;
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression To;
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression LerpFactor;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Vector3.Lerp(From.GetResult<Vector3>(context), To.GetResult<Vector3>(context), LerpFactor.GetResult<float>(context));
    }
}
