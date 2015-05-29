using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Vector4 To Color")]
[UnitFriendlyName("Color.Vector4ToColor")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorVector4ToColor : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression V;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (UnityEngine.Color)V.GetResult<UnityEngine.Vector4>(context);
    }
}
