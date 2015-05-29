using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Sweep Test All (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Sweep Test All")]
[UnitUsage(typeof(UnityEngine.RaycastHit[]), HideExpressionInActionsList = true)]
public class JLRigidbodySweepTestAll2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Direction;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        return opValue.SweepTestAll(Direction.GetResult<UnityEngine.Vector3>(context), Distance.GetResult<System.Single>(context));
    }
}
