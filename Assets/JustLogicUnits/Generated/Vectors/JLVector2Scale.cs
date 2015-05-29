using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Scale (Vector2)")]
[UnitFriendlyName("Scale")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2Scale : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Scale;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector2 opValue = OperandValue.GetResult<UnityEngine.Vector2>(context);
        opValue.Scale(Scale.GetResult<UnityEngine.Vector2>(context));
        return opValue;
    }
}
