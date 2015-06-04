using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Torque (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Torque")]
public class JLRigidbodyAddTorque2 : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Torque;

    [Parameter(ExpressionType = typeof(ForceMode))]
    public JLExpression Mode;

    [Parameter]
    public bool Relative;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        if (Relative)
        opValue.AddTorque(Torque.GetResult<Vector3>(context), Mode.GetResult<ForceMode>(context));
        else
            opValue.AddRelativeTorque(Torque.GetResult<Vector3>(context), Mode.GetResult<ForceMode>(context));
        return null;
    }
}
