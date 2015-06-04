using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Active Self")]
[UnitFriendlyName("Get Active Self")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGameObjectGetActiveSelf : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.activeSelf;
    }
}
