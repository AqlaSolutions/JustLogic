using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Button Up")]
[UnitFriendlyName("Get Button Up")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetButtonUp : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression ButtonName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetButtonUp(ButtonName.GetResult<System.String>(context));
    }
}
