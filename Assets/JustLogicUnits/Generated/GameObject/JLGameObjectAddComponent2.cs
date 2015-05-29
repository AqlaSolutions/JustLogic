using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Add Component")]
[UnitFriendlyName("Add Component")]
[UnitUsage(typeof(UnityEngine.Component))]
public class JLGameObjectAddComponent2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression ComponentType;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.AddComponent(ComponentType.GetResult<System.Type>(context));
    }
}
