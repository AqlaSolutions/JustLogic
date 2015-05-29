using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/This Game Object")]
[UnitMenu("Object/This Game Object")]
[UnitUsage(typeof(GameObject), HideExpressionInActionsList = true)]
public class JLThisGameObject : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return context.ExecutorObject;
    }
}
