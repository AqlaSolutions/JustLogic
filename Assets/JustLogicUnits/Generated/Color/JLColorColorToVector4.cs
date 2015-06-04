using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Color To Vector4")]
[UnitFriendlyName("Color.ColorToVector4")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLColorColorToVector4 : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression C;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Vector4)C.GetResult<Color>(context);
    }
}
