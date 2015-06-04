using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Z (Vector3)")]
[UnitFriendlyName("Get Z")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3GetZ : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = OperandValue.GetResult<Vector3>(context);
        return opValue.z;
    }
}
