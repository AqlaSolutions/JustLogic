using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Mouse Button")]
[UnitFriendlyName("Get Mouse Button")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetMouseButton : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Button;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetMouseButton(Button.GetResult<System.Int32>(context));
    }
}
