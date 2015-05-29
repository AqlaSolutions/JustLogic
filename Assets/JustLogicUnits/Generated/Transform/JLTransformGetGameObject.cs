using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Game Object")]
[UnitFriendlyName("Get Game Object")]
[UnitUsage(typeof(UnityEngine.GameObject), HideExpressionInActionsList = true)]
public class JLTransformGetGameObject : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.gameObject;
    }
}
