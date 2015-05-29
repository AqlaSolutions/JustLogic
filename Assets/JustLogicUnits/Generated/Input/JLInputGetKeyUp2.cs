using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Key Up")]
[UnitFriendlyName("Get Key Up")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetKeyUp2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.KeyCode))]
    public JLExpression Key;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetKeyUp(Key.GetResult<UnityEngine.KeyCode>(context));
    }
}
