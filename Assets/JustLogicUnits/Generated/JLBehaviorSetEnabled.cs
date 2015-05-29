using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Enabled")]
[UnitFriendlyName("Object.Set Enabled")]
[UnitUsage(typeof(System.Boolean))]
public class JLBehaviorSetEnabled : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Behaviour))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Behaviour opValue = OperandValue.GetResult<UnityEngine.Behaviour>(context);
        return opValue.enabled = Value.GetResult<System.Boolean>(context);
    }
}
