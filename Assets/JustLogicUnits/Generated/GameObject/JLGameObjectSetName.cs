using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Name")]
[UnitFriendlyName("Set Name")]
[UnitUsage(typeof(System.String))]
public class JLGameObjectSetName : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.name = Value.GetResult<System.String>(context);
    }
}
