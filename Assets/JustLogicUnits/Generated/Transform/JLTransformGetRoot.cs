using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Root")]
[UnitFriendlyName("Get Root")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLTransformGetRoot : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.root;
    }
}
