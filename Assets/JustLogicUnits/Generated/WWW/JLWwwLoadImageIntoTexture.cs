using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Load Image Into Texture")]
[UnitFriendlyName("WWW.Load Image Into Texture")]
public class JLWwwLoadImageIntoTexture : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture2D))]
    public JLExpression Tex;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        opValue.LoadImageIntoTexture(Tex.GetResult<UnityEngine.Texture2D>(context));
        return null;
    }
}
