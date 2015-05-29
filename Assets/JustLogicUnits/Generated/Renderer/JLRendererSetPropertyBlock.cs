using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Property Block")]
[UnitFriendlyName("Renderer.Set Property Block")]
public class JLRendererSetPropertyBlock : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.MaterialPropertyBlock))]
    public JLExpression Properties;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        opValue.SetPropertyBlock(Properties.GetResult<UnityEngine.MaterialPropertyBlock>(context));
        return null;
    }
}
