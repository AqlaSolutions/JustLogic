using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Set Property Block")]
[UnitFriendlyName("Renderer.Set Property Block")]
public class JLRendererSetPropertyBlock : JLAction
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(MaterialPropertyBlock))]
    public JLExpression Properties;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        opValue.SetPropertyBlock(Properties.GetResult<MaterialPropertyBlock>(context));
        return null;
    }
}
