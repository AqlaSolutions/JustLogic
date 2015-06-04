using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Scale (Vector4)")]
[UnitFriendlyName("Scale")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4Scale : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression Scale;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        opValue.Scale(Scale.GetResult<Vector4>(context));
        return opValue;
    }
}
