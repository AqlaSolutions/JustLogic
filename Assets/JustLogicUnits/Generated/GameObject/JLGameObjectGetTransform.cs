using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Transform")]
[UnitFriendlyName("Get Transform")]
[UnitUsage(typeof(UnityEngine.Transform), HideExpressionInActionsList = true)]
public class JLGameObjectGetTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.transform;
    }
}
