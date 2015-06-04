using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Local To World Matrix")]
[UnitFriendlyName("Renderer.Get Local To World Matrix")]
[UnitUsage(typeof(Matrix4x4), HideExpressionInActionsList = true)]
public class JLRendererGetLocalToWorldMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.localToWorldMatrix;
    }
}
