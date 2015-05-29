using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Get Builtin Resource")]
[UnitFriendlyName("Resources.Get Builtin Resource")]
[UnitUsage(typeof(UnityEngine.Object), HideExpressionInActionsList = true)]
public class JLResourcesGetBuiltinResource : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Resources.GetBuiltinResource(Type.GetResult<System.Type>(context), Path.GetResult<System.String>(context));
    }
}
