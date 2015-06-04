using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set R")]
[UnitFriendlyName("Color.Set R")]
[UnitUsage(typeof(System.Single))]
public class JLColorSetR : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = Target.GetResult<Color>(context);
        return opValue.r = Value.GetResult<System.Single>(context);
    }
}
