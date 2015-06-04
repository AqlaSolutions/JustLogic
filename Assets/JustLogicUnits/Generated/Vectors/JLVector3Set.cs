using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Set/Set (Vector3)")]
[UnitFriendlyName("Set")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Set : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewX;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewY;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewZ;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = OperandValue.GetResult<Vector3>(context);
        opValue.Set(NewX.GetResult<System.Single>(context), NewY.GetResult<System.Single>(context), NewZ.GetResult<System.Single>(context));
        return opValue;
    }
}
