using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Composition String")]
[UnitFriendlyName("Get Composition String")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLInputGetCompositionString : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.compositionString;
    }
}
