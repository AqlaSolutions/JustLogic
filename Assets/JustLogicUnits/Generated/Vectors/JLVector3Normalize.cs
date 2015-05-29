using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Normalize (Vector3)")]
[UnitFriendlyName("Normalize")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Normalize : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector3 opValue = OperandValue.GetResult<UnityEngine.Vector3>(context);
        opValue.Normalize();
        return opValue;
    }
}
