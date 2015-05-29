using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Mouse Button Up")]
[UnitFriendlyName("Get Mouse Button Up")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetMouseButtonUp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Button;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetMouseButtonUp(Button.GetResult<System.Int32>(context));
    }
}
