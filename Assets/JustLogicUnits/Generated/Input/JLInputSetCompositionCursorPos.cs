using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Composition Cursor Pos")]
[UnitFriendlyName("Set Composition Cursor Pos")]
[UnitUsage(typeof(UnityEngine.Vector2))]
public class JLInputSetCompositionCursorPos : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.compositionCursorPos = Value.GetResult<UnityEngine.Vector2>(context);
    }
}
