using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector4)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector4.Lerp(From.GetResult<UnityEngine.Vector4>(context), To.GetResult<UnityEngine.Vector4>(context), T.GetResult<System.Single>(context));
    }
}
