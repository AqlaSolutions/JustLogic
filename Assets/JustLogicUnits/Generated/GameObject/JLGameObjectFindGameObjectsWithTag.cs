using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Find Game Objects With Tag")]
[UnitFriendlyName("Find Game Objects With Tag")]
[UnitUsage(typeof(GameObject[]), HideExpressionInActionsList = true)]
public class JLGameObjectFindGameObjectsWithTag : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Tag;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GameObject.FindGameObjectsWithTag(Tag.GetResult<System.String>(context));
    }
}
