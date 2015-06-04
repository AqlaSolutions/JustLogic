using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Composition Cursor Pos")]
[UnitFriendlyName("Set Composition Cursor Pos")]
[UnitUsage(typeof(Vector2))]
public class JLInputSetCompositionCursorPos : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.compositionCursorPos = Value.GetResult<Vector2>(context);
    }
}
