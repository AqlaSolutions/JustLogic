using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Is Static")]
[UnitFriendlyName("Get Is Static")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGameObjectGetIsStatic : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.isStatic;
    }
}
