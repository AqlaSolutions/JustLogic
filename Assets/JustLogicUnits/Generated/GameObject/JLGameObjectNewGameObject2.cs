using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/New Game Object")]
[UnitFriendlyName("New Game Object")]
[UnitUsage(typeof(UnityEngine.GameObject), HideExpressionInActionsList = true)]
public class JLGameObjectNewGameObject2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.GameObject(Name.GetResult<System.String>(context));
    }
}
