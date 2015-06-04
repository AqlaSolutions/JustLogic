using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Load")]
[UnitFriendlyName("Resources.Load")]
[UnitUsage(typeof(Object), HideExpressionInActionsList = true)]
public class JLResourcesLoad : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Resources.Load(Path.GetResult<System.String>(context));
    }
}
