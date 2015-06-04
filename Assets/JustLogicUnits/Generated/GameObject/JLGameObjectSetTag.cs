using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Tag")]
[UnitFriendlyName("Set Tag")]
[UnitUsage(typeof(System.String))]
public class JLGameObjectSetTag : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.tag = Value.GetResult<System.String>(context);
    }
}
