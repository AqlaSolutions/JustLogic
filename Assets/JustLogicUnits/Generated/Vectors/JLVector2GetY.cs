using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Y (Vector2)")]
[UnitFriendlyName("Get Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector2GetY : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector2 opValue = OperandValue.GetResult<UnityEngine.Vector2>(context);
        return opValue.y;
    }
}
