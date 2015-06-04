using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get World To Local Matrix")]
[UnitFriendlyName("Renderer.Get World To Local Matrix")]
[UnitUsage(typeof(Matrix4x4), HideExpressionInActionsList = true)]
public class JLRendererGetWorldToLocalMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.worldToLocalMatrix;
    }
}
