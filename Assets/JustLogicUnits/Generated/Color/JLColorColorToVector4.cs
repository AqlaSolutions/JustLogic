using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Color To Vector4")]
[UnitFriendlyName("Color.ColorToVector4")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLColorColorToVector4 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression C;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (UnityEngine.Vector4)C.GetResult<UnityEngine.Color>(context);
    }
}
