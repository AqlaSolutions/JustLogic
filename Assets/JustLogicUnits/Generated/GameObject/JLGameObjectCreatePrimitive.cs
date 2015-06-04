using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Create Primitive")]
[UnitFriendlyName("Create Primitive")]
[UnitUsage(typeof(GameObject))]
public class JLGameObjectCreatePrimitive : JLExpression
{
    [Parameter(ExpressionType = typeof(PrimitiveType))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GameObject.CreatePrimitive(Type.GetResult<PrimitiveType>(context));
    }
}
