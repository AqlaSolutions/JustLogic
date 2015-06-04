using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Explosion Force (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Explosion Force")]
public class JLRigidbodyAddExplosionForce3 : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression ExplosionForce;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression ExplosionPosition;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression ExplosionRadius;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression UpwardsModifier;

    [Parameter(ExpressionType = typeof(ForceMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        opValue.AddExplosionForce(ExplosionForce.GetResult<System.Single>(context), ExplosionPosition.GetResult<Vector3>(context), ExplosionRadius.GetResult<System.Single>(context), UpwardsModifier.GetResult<System.Single>(context), Mode.GetResult<ForceMode>(context));
        return null;
    }
}
