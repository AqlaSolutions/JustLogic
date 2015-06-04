using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Sweep Test All (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Sweep Test All")]
[UnitUsage(typeof(RaycastHit[]), HideExpressionInActionsList = true)]
public class JLRigidbodySweepTestAll2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Direction;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.SweepTestAll(Direction.GetResult<Vector3>(context), Distance.GetResult<System.Single>(context));
    }
}
