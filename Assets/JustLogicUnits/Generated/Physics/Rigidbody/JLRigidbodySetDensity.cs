using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Density (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Set Density")]
public class JLRigidbodySetDensity : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Density;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        opValue.SetDensity(Density.GetResult<System.Single>(context));
        return null;
    }
}
