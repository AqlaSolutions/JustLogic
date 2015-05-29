using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Local Scale")]
[UnitFriendlyName("Get Local Scale")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLTransformGetLocalScale : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.localScale;
    }
}
