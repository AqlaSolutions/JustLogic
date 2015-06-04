using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Ignore Collision")]
[UnitFriendlyName("Ignore Collision")]
public class JLPhysicsIgnoreCollision2 : JLAction
{
    [Parameter(ExpressionType = typeof(Collider))]
    public JLExpression Collider1;

    [Parameter(ExpressionType = typeof(Collider))]
    public JLExpression Collider2;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Ignore;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Physics.IgnoreCollision(Collider1.GetResult<Collider>(context), Collider2.GetResult<Collider>(context), Ignore.GetResult<System.Boolean>(context));
        return null;
    }
}
