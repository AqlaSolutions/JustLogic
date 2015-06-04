using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Mouse Button Down")]
[UnitFriendlyName("Get Mouse Button Down")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetMouseButtonDown : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Button;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetMouseButtonDown(Button.GetResult<System.Int32>(context));
    }
}
