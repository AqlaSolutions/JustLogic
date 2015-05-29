using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Button")]
[UnitFriendlyName("Get Button")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetButton : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression ButtonName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetButton(ButtonName.GetResult<System.String>(context));
    }
}
