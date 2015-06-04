using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Key Up")]
[UnitFriendlyName("Get Key Up")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetKeyUp2 : JLExpression
{
    [Parameter(ExpressionType = typeof(KeyCode))]
    public JLExpression Key;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetKeyUp(Key.GetResult<KeyCode>(context));
    }
}
