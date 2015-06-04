using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Vector4 To Color")]
[UnitFriendlyName("Color.Vector4ToColor")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorVector4ToColor : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression V;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Color)V.GetResult<Vector4>(context);
    }
}
