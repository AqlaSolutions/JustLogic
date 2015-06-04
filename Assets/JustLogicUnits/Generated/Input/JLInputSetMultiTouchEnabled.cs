using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Multi Touch Enabled")]
[UnitFriendlyName("Set Multi Touch Enabled")]
[UnitUsage(typeof(System.Boolean))]
public class JLInputSetMultiTouchEnabled : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.multiTouchEnabled = Value.GetResult<System.Boolean>(context);
    }
}
