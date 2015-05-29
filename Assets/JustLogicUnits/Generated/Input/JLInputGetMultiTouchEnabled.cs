using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Multi Touch Enabled")]
[UnitFriendlyName("Get Multi Touch Enabled")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetMultiTouchEnabled : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.multiTouchEnabled;
    }
}
