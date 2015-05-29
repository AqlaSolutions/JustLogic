using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set B")]
[UnitFriendlyName("Color.Set B")]
[UnitUsage(typeof(System.Single))]
public class JLColorSetB : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = Target.GetResult<UnityEngine.Color>(context);
        return opValue.b = Value.GetResult<System.Single>(context);
    }
}
