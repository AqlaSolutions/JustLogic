using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Ignore Collision")]
[UnitFriendlyName("Ignore Collision")]
public class JLPhysicsIgnoreCollision2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collider))]
    public JLExpression Collider1;

    [Parameter(ExpressionType = typeof(UnityEngine.Collider))]
    public JLExpression Collider2;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Ignore;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Physics.IgnoreCollision(Collider1.GetResult<UnityEngine.Collider>(context), Collider2.GetResult<UnityEngine.Collider>(context), Ignore.GetResult<System.Boolean>(context));
        return null;
    }
}
