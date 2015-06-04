using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Renderer/Get Is Part Of Static Batch")]
[UnitFriendlyName("Renderer.Get Is Part Of Static Batch")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRendererGetIsPartOfStaticBatch : JLExpression
{
    [Parameter(ExpressionType = typeof(Renderer))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Renderer opValue = OperandValue.GetResult<Renderer>(context);
        return opValue.isPartOfStaticBatch;
    }
}
