using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Child Count")]
[UnitFriendlyName("Get Child Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLTransformGetChildCount : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.childCount;
    }
}
