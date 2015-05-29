using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set G")]
[UnitFriendlyName("Color.Set G")]
[UnitUsage(typeof(System.Single))]
public class JLColorSetG : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = Target.GetResult<UnityEngine.Color>(context);
        return opValue.g = Value.GetResult<System.Single>(context);
    }
}
