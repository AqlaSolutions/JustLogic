using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Active In Hierarchy")]
[UnitFriendlyName("Get Active In Hierarchy")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGameObjectGetActiveInHierarchy : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.activeInHierarchy;
    }
}
