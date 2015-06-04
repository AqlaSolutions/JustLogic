using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Load Image Into Texture")]
[UnitFriendlyName("WWW.Load Image Into Texture")]
public class JLWwwLoadImageIntoTexture : JLAction
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Texture2D))]
    public JLExpression Tex;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        opValue.LoadImageIntoTexture(Tex.GetResult<Texture2D>(context));
        return null;
    }
}
