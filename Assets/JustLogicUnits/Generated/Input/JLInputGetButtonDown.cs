using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Button Down")]
[UnitFriendlyName("Get Button Down")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetButtonDown : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression ButtonName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetButtonDown(ButtonName.GetResult<System.String>(context));
    }
}
