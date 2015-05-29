using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Renderer")]
[UnitFriendlyName("Get Renderer")]
[UnitUsage(typeof(UnityEngine.Renderer), HideExpressionInActionsList = true)]
public class JLGameObjectGetRenderer : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Renderer>();
    }
}
