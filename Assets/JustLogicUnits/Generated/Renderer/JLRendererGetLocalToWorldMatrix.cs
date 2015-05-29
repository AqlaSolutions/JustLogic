using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Local To World Matrix")]
[UnitFriendlyName("Renderer.Get Local To World Matrix")]
[UnitUsage(typeof(UnityEngine.Matrix4x4), HideExpressionInActionsList = true)]
public class JLRendererGetLocalToWorldMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Renderer opValue = OperandValue.GetResult<UnityEngine.Renderer>(context);
        return opValue.localToWorldMatrix;
    }
}
