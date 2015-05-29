using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Find")]
[UnitFriendlyName("Find")]
[UnitUsage(typeof(UnityEngine.GameObject), HideExpressionInActionsList = true)]
public class JLGameObjectFind : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GameObject.Find(Name.GetResult<System.String>(context));
    }
}
