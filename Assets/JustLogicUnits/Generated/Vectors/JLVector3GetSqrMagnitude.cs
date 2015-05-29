using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Sqr Magnitude (Vector3)")]
[UnitFriendlyName("Get Sqr Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3GetSqrMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector3 opValue = OperandValue.GetResult<UnityEngine.Vector3>(context);
        return opValue.sqrMagnitude;
    }
}
