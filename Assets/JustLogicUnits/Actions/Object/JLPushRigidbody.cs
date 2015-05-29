using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Physics/Add Force (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add force")]
public class JLPushRigidbody : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Force;

    [Parameter]
    public bool Relative = true;

    [Parameter]
    public ForceMode Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var rb = Value.GetResult<Rigidbody>(context);
        if (Relative)
            rb.AddRelativeForce(Force.GetResult<Vector3>(context), Mode);
        else
            rb.AddForce(Force.GetResult<Vector3>(context), Mode);
        yield break;
    }
}
