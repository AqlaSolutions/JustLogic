using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Light")]
[UnitFriendlyName("Get Light")]
[UnitUsage(typeof(UnityEngine.Light), HideExpressionInActionsList = true)]
public class JLGameObjectGetLight : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Light>();
    }
}
