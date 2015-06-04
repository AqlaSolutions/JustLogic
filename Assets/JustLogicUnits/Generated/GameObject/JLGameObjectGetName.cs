using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Name")]
[UnitFriendlyName("Get Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLGameObjectGetName : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.name;
    }
}
