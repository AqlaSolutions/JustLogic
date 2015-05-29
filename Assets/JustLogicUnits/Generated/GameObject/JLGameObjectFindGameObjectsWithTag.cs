using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Find Game Objects With Tag")]
[UnitFriendlyName("Find Game Objects With Tag")]
[UnitUsage(typeof(UnityEngine.GameObject[]), HideExpressionInActionsList = true)]
public class JLGameObjectFindGameObjectsWithTag : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Tag;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GameObject.FindGameObjectsWithTag(Tag.GetResult<System.String>(context));
    }
}
