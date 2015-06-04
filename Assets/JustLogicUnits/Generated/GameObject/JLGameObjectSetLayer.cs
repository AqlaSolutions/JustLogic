using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Layer")]
[UnitFriendlyName("Set Layer")]
[UnitUsage(typeof(System.Int32))]
public class JLGameObjectSetLayer : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.layer = Value.GetResult<System.Int32>(context);
    }
}
