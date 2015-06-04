using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Ime Composition Mode")]
[UnitFriendlyName("Set Ime Composition Mode")]
[UnitUsage(typeof(IMECompositionMode))]
public class JLInputSetImeCompositionMode : JLExpression
{
    [Parameter(ExpressionType = typeof(IMECompositionMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.imeCompositionMode = Value.GetResult<IMECompositionMode>(context);
    }
}
