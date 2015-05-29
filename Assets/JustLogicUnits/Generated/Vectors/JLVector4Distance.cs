using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Distance (Vector4)")]
[UnitFriendlyName("Distance")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4Distance : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector4.Distance(A.GetResult<UnityEngine.Vector4>(context), B.GetResult<UnityEngine.Vector4>(context));
    }
}
