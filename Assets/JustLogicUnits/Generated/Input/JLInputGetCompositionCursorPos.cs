using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Composition Cursor Pos")]
[UnitFriendlyName("Get Composition Cursor Pos")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLInputGetCompositionCursorPos : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.compositionCursorPos;
    }
}
