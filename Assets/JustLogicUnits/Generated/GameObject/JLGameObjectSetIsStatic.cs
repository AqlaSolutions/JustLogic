using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Is Static")]
[UnitFriendlyName("Set Is Static")]
[UnitUsage(typeof(System.Boolean))]
public class JLGameObjectSetIsStatic : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.isStatic = Value.GetResult<System.Boolean>(context);
    }
}
