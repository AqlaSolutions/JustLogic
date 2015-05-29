using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Sqr Magnitude (Vector2)")]
[UnitFriendlyName("Sqr Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2SqrMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector2 opValue = OperandValue.GetResult<UnityEngine.Vector2>(context);
        return opValue.SqrMagnitude();
    }
}
