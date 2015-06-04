using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Light")]
[UnitFriendlyName("Get Light")]
[UnitUsage(typeof(Light), HideExpressionInActionsList = true)]
public class JLGameObjectGetLight : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<Light>();
    }
}
