using JustLogic.Core;
using UnityEngine;

[UnitMenu("Math/Lerp (Quaternion)")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLLerpQuaternion : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression From;
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression To;
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression LerpFactor;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Lerp(From.GetResult<Quaternion>(context), To.GetResult<Quaternion>(context), LerpFactor.GetResult<float>(context));
    }
}
