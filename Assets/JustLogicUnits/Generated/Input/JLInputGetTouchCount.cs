using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Touch Count")]
[UnitFriendlyName("Get Touch Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLInputGetTouchCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.touchCount;
    }
}
