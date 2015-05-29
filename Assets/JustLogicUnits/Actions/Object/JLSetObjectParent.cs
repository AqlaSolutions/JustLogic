using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Set Parent")]
public class JLSetObjectParent : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Parent;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Object.GetResult<Transform>(context).parent = Parent.GetResult<Transform>(context);
        yield break;
    }
}
