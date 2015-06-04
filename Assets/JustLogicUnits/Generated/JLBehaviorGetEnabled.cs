using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Enabled")]
[UnitFriendlyName("Object.Get Enabled")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLBehaviorGetEnabled : JLExpression
{
    [Parameter(ExpressionType = typeof(Behaviour))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Behaviour opValue = OperandValue.GetResult<Behaviour>(context);
        return opValue.enabled;
    }
}
