using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Scale (Vector3)")]
[UnitFriendlyName("Scale")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Scale : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Scale;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector3 opValue = OperandValue.GetResult<UnityEngine.Vector3>(context);
        opValue.Scale(Scale.GetResult<UnityEngine.Vector3>(context));
        return opValue;
    }
}
