using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Parent")]
[UnitFriendlyName("Get Parent")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLTransformGetParent : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.parent;
    }
}
