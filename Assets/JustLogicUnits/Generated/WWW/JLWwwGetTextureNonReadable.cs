using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Texture Non Readable")]
[UnitFriendlyName("WWW.Get Texture Non Readable")]
[UnitUsage(typeof(UnityEngine.Texture2D), HideExpressionInActionsList = true)]
public class JLWwwGetTextureNonReadable : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.textureNonReadable;
    }
}
