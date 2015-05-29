using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Ime Composition Mode")]
[UnitFriendlyName("Set Ime Composition Mode")]
[UnitUsage(typeof(UnityEngine.IMECompositionMode))]
public class JLInputSetImeCompositionMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.IMECompositionMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.imeCompositionMode = Value.GetResult<UnityEngine.IMECompositionMode>(context);
    }
}
