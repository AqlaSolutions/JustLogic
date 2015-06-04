using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Input String")]
[UnitFriendlyName("Get Input String")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLInputGetInputString : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.inputString;
    }
}
