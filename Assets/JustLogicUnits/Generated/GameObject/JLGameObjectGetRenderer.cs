using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Renderer")]
[UnitFriendlyName("Get Renderer")]
[UnitUsage(typeof(Renderer), HideExpressionInActionsList = true)]
public class JLGameObjectGetRenderer : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<Renderer>();
    }
}
