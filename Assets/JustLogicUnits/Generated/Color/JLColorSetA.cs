using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set A")]
[UnitFriendlyName("Color.Set A")]
[UnitUsage(typeof(System.Single))]
public class JLColorSetA : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = Target.GetResult<UnityEngine.Color>(context);
        return opValue.a = Value.GetResult<System.Single>(context);
    }
}
