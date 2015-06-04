using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Animation")]
[UnitFriendlyName("Get Animation")]
[UnitUsage(typeof(Animation), HideExpressionInActionsList = true)]
public class JLGameObjectGetAnimation : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<Animation>();
    }
}
