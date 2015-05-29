using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Torque (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Torque")]
public class JLRigidbodyAddTorque2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Torque;

    [Parameter(ExpressionType = typeof(UnityEngine.ForceMode))]
    public JLExpression Mode;

    [Parameter]
    public bool Relative;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        if (Relative)
        opValue.AddTorque(Torque.GetResult<UnityEngine.Vector3>(context), Mode.GetResult<UnityEngine.ForceMode>(context));
        else
            opValue.AddRelativeTorque(Torque.GetResult<UnityEngine.Vector3>(context), Mode.GetResult<UnityEngine.ForceMode>(context));
        return null;
    }
}
