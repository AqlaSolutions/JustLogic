using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Key")]
[UnitFriendlyName("Get Key")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetKey2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.KeyCode))]
    public JLExpression Key;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.GetKey(Key.GetResult<UnityEngine.KeyCode>(context));
    }
}
