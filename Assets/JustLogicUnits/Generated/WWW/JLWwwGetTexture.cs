using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Texture")]
[UnitFriendlyName("WWW.Get Texture")]
[UnitUsage(typeof(UnityEngine.Texture2D), HideExpressionInActionsList = true)]
public class JLWwwGetTexture : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.texture;
    }
}
