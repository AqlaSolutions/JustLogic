using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Load All")]
[UnitFriendlyName("Resources.Load All")]
[UnitUsage(typeof(Object[]), HideExpressionInActionsList = true)]
public class JLResourcesLoadAll : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Resources.LoadAll(Path.GetResult<System.String>(context));
    }
}
