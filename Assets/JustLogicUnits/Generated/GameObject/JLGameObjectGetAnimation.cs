using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Animation")]
[UnitFriendlyName("Get Animation")]
[UnitUsage(typeof(UnityEngine.Animation), HideExpressionInActionsList = true)]
public class JLGameObjectGetAnimation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Animation>();
    }
}
