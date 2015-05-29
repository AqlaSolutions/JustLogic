using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get X (Vector3)")]
[UnitFriendlyName("Get X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3GetX : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector3 opValue = OperandValue.GetResult<UnityEngine.Vector3>(context);
        return opValue.x;
    }
}
