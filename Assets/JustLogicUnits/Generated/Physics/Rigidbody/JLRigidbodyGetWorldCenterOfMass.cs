using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get World Center Of Mass (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get World Center Of Mass")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyGetWorldCenterOfMass : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.worldCenterOfMass;
    }
}
