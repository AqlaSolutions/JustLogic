using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Key Down")]
[UnitFriendlyName("Get Key Down")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetKeyDown2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.KeyCode))]
    public JLExpression Key;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetKeyDown(Key.GetResult<UnityEngine.KeyCode>(context));
    }
}
