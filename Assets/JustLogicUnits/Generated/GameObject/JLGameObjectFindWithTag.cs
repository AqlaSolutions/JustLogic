using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Find With Tag")]
[UnitFriendlyName("Find With Tag")]
[UnitUsage(typeof(GameObject), HideExpressionInActionsList = true)]
public class JLGameObjectFindWithTag : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Tag;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GameObject.FindWithTag(Tag.GetResult<System.String>(context));
    }
}
