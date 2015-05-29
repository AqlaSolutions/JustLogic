using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Create Primitive")]
[UnitFriendlyName("Create Primitive")]
[UnitUsage(typeof(UnityEngine.GameObject))]
public class JLGameObjectCreatePrimitive : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.PrimitiveType))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GameObject.CreatePrimitive(Type.GetResult<UnityEngine.PrimitiveType>(context));
    }
}
