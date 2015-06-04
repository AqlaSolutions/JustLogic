using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Tag")]
[UnitFriendlyName("Get Tag")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLGameObjectGetTag : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.tag;
    }
}
